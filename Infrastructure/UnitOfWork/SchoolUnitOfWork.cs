
using Application.IReposotory;
using Application.IUnitOfWork;
using Application.Models;
using Infrastructure.Reposotory;
using Microsoft.EntityFrameworkCore.Storage;


namespace Infrastructure.UnitOfWork
{
    public class SchoolUnitOfWork : IUnitOfWork
    {
        private readonly SchoolSystemContext _context;
        public IGenaricReposotory<Room> Room { get; private set; }

        public IGenaricReposotory<Teacher> Teacher { get; private set; }

        public IGenaricReposotory<Student> Student { get; private set; }

        public IGenaricReposotory<Equipment> Equipment { get; private set; }

        public IGenaricReposotory<Department> Department { get; private set; }

        public IGenaricReposotory<Donation> Donation { get; private set; }

        public IGenaricReposotory<Employee> Employee { get; private set; }

        public IGenaricReposotory<Event> Event { get; private set; }

        public IGenaricReposotory<EventSpeaker> EventSpeaker { get; private set; }

        public IGenaricReposotory<Subject> Subject { get; private set; }

        public IGenaricReposotory<NotesBoard> NotesBoard { get; private set; }

        public IGenaricReposotory<Transport> Transport { get; private set; }

        public SchoolUnitOfWork(SchoolSystemContext context)
        {
            _context = context;
            Room = new GenaricReposotory<Room>(_context);
            Teacher = new GenaricReposotory<Teacher>(_context);
            Student = new GenaricReposotory<Student>(_context);
            Equipment = new GenaricReposotory<Equipment>(_context);
            Department = new GenaricReposotory<Department>(_context);
            Donation = new GenaricReposotory<Donation>(_context);
            Employee = new GenaricReposotory<Employee>(_context);
            Event = new GenaricReposotory<Event>(_context);
            EventSpeaker = new GenaricReposotory<EventSpeaker>(_context);
            Subject = new GenaricReposotory<Subject>(_context);
            NotesBoard = new GenaricReposotory<NotesBoard>(_context);
            Transport = new GenaricReposotory<Transport>(_context);
        }

        

        public void Dispose()
        {
           _context.Dispose();

        }

        
        public int SaveAction()
        {
           return _context.SaveChanges();
        }

        public IDbContextTransaction Transaction()
        {
           return _context.Database.BeginTransaction();
        }
    }
}
