using AutoMapper;
using System.Reflection;

namespace Magical.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => // 1) приватный метод прин. сборку в кач-че параметра
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            // 2) Создается экземляр класса 'IMapFrom<>',
            //который определяет интерфейс для маппинга объектов.
            var mapFromType = typeof(IMapFrom<>);

            // 3) Получается имя метода маппинга 'Mapping' через рефлексию
            var mappingMethodName = nameof(IMapFrom<object>.Mapping);

            // 4) Объявляется лямбда-выражение 'HasInterface' которое проверяет
            //является ли тип универсальным и соответствует ли определению класса 'IMapFrom<>'
            bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;

            // 5) Получается список всех типов в сборке, которые реализуют интерфейс 'IMapFrom<>'
            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();

            // 6) Создается массив типов аргументов, который содержит только тип 'Profile'
            var argumentTypes = new Type[] { typeof(Profile) };

            // 7) для каждого типа в списке типов
            foreach (var type in types)
            {
                // *Создается экземпляр типа
                var instance = Activator.CreateInstance(type);
                
                // *Получается метод 'Mapping'
                var methodInfo = type.GetMethod(mappingMethodName);

                // *Если метод существует, вызывается этот метод,
                // Передававя экземпляр класса 'Profile' в качестве аргумента.
                if (methodInfo != null)
                    methodInfo.Invoke(instance, new object[] { this });

                //Если метод не существует
                else
                {   //Получается список всех интерфейсов типа, которые соотв определению класса 'IMapFrom<>'
                    var interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                    if (interfaces.Count > 0)
                    {   // *Для каждого интерфейса в списке
                        foreach (var @interface  in interfaces)
                        {   //Получается метод 'Mapping', который принимает массив типов аргументов.
                            var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);

                            // *Если метод существует, вызывается этот метод, передавая
                            // экземпляр класса 'Profile' в качестве аргумента.
                            interfaceMethodInfo?.Invoke(instance, new object[] { this });
                        }
                    }
                }
            }
        }
    }
}
