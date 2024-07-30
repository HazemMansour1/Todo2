using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo2.Domain;
using Todo2.Infrastructure;

namespace Todo2.Application
{
    public class ToDoService
    {
        private readonly AppDbContext _dbContext;

        public ToDoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<toDo>> GetAllTasks()
        {

            return await _dbContext.ToDos.ToListAsync();
        }

        public async Task<toDo> GetTask(int num)
        {
            return await _dbContext.ToDos.SingleOrDefaultAsync(t => t.taskNum == num);
        }
        public async Task<toDo> AddTaskAsync(toDo toDoItem)
        {
            _dbContext.ToDos.Add(toDoItem);
            await _dbContext.SaveChangesAsync();
            return toDoItem;
        }
        public async Task<toDo> UpdateTask(toDo updatedTask)
        {
            var task = await _dbContext.ToDos.SingleOrDefaultAsync(t => t.taskNum == updatedTask.taskNum);
            if (task == null)
            {
                return null;
            }

            task.taskName = updatedTask.taskName;
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<bool> RemoveTask(int taskNum)
        {
            var task = await _dbContext.ToDos.SingleOrDefaultAsync(t => t.taskNum == taskNum);

            if (task == null)
            {
                return false;   
            }

            _dbContext.ToDos.Remove(task);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
