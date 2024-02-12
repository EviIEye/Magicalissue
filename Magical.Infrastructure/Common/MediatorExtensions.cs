using Magical.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Infrastructure.Common
{
    public static class MediatorExtensions//Это метод расширения интерфейса "IMediator".
    {                                     //Он позволяет вам отправлять события домена
                                          //из сущностей в "DbContext", используя шаблон mediator.
        public static async Task DispatchDomainEvents(this IMediator mediator, DbContext context)
        {
                                                  //1)Он извлекает все объекты в "ChangeTracker" из "DbContext", 
            var entities = context.ChangeTracker //которые являются производными от "BaseEntity" 
                .Entries<BaseEntity>()          //и к которым привязано по крайней мере одно событие домена.
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity);

            var domainEvents = entities           //Он извлекает все события домена  
                .SelectMany(e => e.DomainEvents)  //из этих объектов
                .ToList();                        //и помещает их в список.

            // Он очищает события домена от каждой сущности.
            entities.ToList().ForEach(e => e.ClearDomainEvent());

            foreach (var domainEvent in domainEvents) //Наконец, он выполняет итерацию по событиям домена 
                await mediator.Publish(domainEvent);  //и публикует каждое из них с помощью посредника.
        }
    }
}
