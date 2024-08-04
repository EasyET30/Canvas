using System.Text.Json;
using Library_Canvas.DTO;
using Library_Canvas.Utilities;

namespace Library_Canvas.Services
{
    public class AssignmentService
    {
        private List<AssignmentDTO> assignments;
        public List<AssignmentDTO> Assignments { 
            get {
                
                return assignments ?? new List<AssignmentDTO>();
            } 
        }

        //private List<Assignment> Assignments;

        private static AssignmentService? instance;

        public static AssignmentService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssignmentService();
                }
                return instance;
            }
        }
        private AssignmentService()
        {
            var response = new WebRequestHandler().Get("/Assignment").Result;
            assignments = JsonSerializer.Deserialize<List<AssignmentDTO>>(response)?? new List<AssignmentDTO>();
        }

        public void Delete(string Id)
        {
            var handler = new WebRequestHandler().Delete($"/Assignment/Delete/{Id}");
            var assignmentDelete = Assignments.FirstOrDefault(a=> a.Id == Id);
            if(assignmentDelete != null){
                Assignments.Remove(assignmentDelete);
            }
        }

        public void AddOrUpdate(AssignmentDTO c)
        {
            var response = new WebRequestHandler().Post("/Assignment/Post", c).Result;
            var myUpdatedAssignment = JsonSerializer.Deserialize<AssignmentDTO>(response);
            if(myUpdatedAssignment != null)
            {
                var existingAssignment = Assignments.FirstOrDefault(c => c.Id == myUpdatedAssignment.Id);
                if(existingAssignment == null)
                {
                    Assignments.Add(myUpdatedAssignment);
                }else
                {
                    var index = Assignments.IndexOf(existingAssignment);
                    Assignments.RemoveAt(index);
                    Assignments.Insert(index, myUpdatedAssignment);
                }
            }

        }

        public AssignmentDTO? Get(string Id)
        {
            var response = new WebRequestHandler()
                    .Get($"/Assignment/GetById/{Id}")
                    .Result;
            var Assignment = JsonSerializer.Deserialize<AssignmentDTO>(response);
            return Assignment;
            //return Assignments.FirstOrDefault(c => c.Id == Id);
        }

        public IEnumerable<AssignmentDTO> Search(string query)
        {
            return Assignments
                .Where(c => c.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}
