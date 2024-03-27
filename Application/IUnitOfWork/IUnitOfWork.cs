

using Application.IReposotory;
using Application.Models;
using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenaricReposotory<Room> Room{get;}
        public IGenaricReposotory<Teacher> Teacher{get;}
        public IGenaricReposotory<Student> Student{get;}
        public IGenaricReposotory<Equipment> Equipment { get;}
        public IGenaricReposotory<Department> Department { get;}
        public IGenaricReposotory<Donation> Donation { get;}
        public IGenaricReposotory<Employee> Employee { get;}
        public IGenaricReposotory<Event> Event { get;}
        public IGenaricReposotory<EventSpeaker> EventSpeaker { get;}
        public IGenaricReposotory<Subject> Subject { get;}
        public IGenaricReposotory<NotesBoard> NotesBoard { get;}
        public IGenaricReposotory<Transport> Transport { get;}

        IDbContextTransaction Transaction();
        void Dispose();
        int SaveAction();
    }
}
