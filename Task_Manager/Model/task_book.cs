using System;

namespace Task_Manager.Model
{
    public class task_book
    {
        public int Number { get; set; }
        public DateTime Date_of_compilation { get; set; }
        public string from_whom { get; set; }
        public string task_type { get; set; }
        public string name_of_the_task { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string executor { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        public string Department { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public string implicit_request { get; set; }
        public bool implicit_request_bool { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj as task_book) != null)
            {
                task_book task = (obj as task_book);
                if (task.Number == Number &
                    task.priority == priority &
                    task.start_date == start_date &
                    task.status == status &
                    task.task_type == task_type &
                    task.name_of_the_task == name_of_the_task &
                    task.implicit_request == implicit_request &
                    task.Department == Department &
                    task.Description == Description &
                    task.from_whom == from_whom)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            else
            {
                return false;
            }
           
        }
        public override int GetHashCode()
        {
            int x = Number.GetHashCode();
            return x;
        }
    }
}
