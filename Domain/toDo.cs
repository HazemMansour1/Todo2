using System.ComponentModel.DataAnnotations;

namespace Todo2.Domain
{
    public class toDo
    {
        [Key]
        public int taskNum { get; set; }

        public string taskName { get; set; }

        public string taskDue { get; set; }

        public Boolean done { get; set; }
    }

}
