using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace Task_Manager.Model
{
    public enum ConditionOper
    {
        Insert,
        Update,
        Delete


    }
    public  class ChangeDataTask_Book
    {
       private static List<task_book> task_Books1 = new Model.CrudOperations.CrudOperations().GetEntityList().ToList();
        public delegate void mycallback(IEnumerable<task_book> task_Book, ConditionOper condition);
     
        public void ChangeData(mycallback mycallback)
        {
            Thread thread = new Thread(() => {
                const double interval60Minutes = 1000;
                System.Timers.Timer checkForTime = new System.Timers.Timer(interval60Minutes);
                checkForTime.Elapsed += new ElapsedEventHandler((s, e) => {
                    List<task_book> task_Books2 = new CrudOperations.CrudOperations().GetEntityList().ToList() ;
                    var g = new HashSet<task_book>(task_Books1).SetEquals(task_Books2);

                    if (g == false)
                    {
                        if (task_Books2.Count > task_Books1.Count)
                        {
                            mycallback(task_Books2.Except(task_Books1), ConditionOper.Insert);
                            task_Books1 = task_Books2;

                         //   MessageBox.Show("Insert");


                        }
                        if (task_Books2.Count < task_Books1.Count)
                        {
                          
                          mycallback(task_Books1.Except(task_Books2), ConditionOper.Delete);
                         
                            task_Books1 = task_Books2;

                            // MessageBox.Show("Delete");



                        }
                        if (task_Books2.Count == task_Books1.Count)
                        {
                            mycallback(task_Books2.Except(task_Books1), ConditionOper.Update);
                            task_Books1 = task_Books2;
                          //  MessageBox.Show("uPDATE");

                        }
                        task_Books1 = task_Books2;

                    }
                    GC.Collect(0, GCCollectionMode.Forced);
                    GC.WaitForPendingFinalizers();
                    //GC.GetGeneration(task_Books2);
                });
                checkForTime.Enabled = true;
            });
            thread.Start();



        }
    }
}
