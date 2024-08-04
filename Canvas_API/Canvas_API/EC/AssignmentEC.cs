
using Canvas_API.Databases;
using Library_Canvas.DTO;
using Library_Canvas.Models;

namespace Canvas_API.EC
{
    public class AssignmentEC
    {
        Filebase Database;
        public AssignmentEC(){
            Database = Filebase.Current;
        }
        public AssignmentDTO? AddOrUpdate(AssignmentDTO dto)
        {
            Assignment created = new Assignment(dto);
            var id = Database.AddOrUpdateAssignment(created);
            return Get(id);
        }
        public AssignmentDTO? Get(string Id)
        {
            var returnVal = Database.Assignments.FirstOrDefault(p=>p.Id == Id) ?? new Assignment();
            return new AssignmentDTO(returnVal);
        }
        public bool Delete(string Id)
        {
            bool returnVal = Database.Delete("Assignment", Id);
            return returnVal;
        }
        public IEnumerable<AssignmentDTO> Search(string query = "")
        {
            return Database.Assignments.Where(m => m.Name.ToUpper().Contains(query.ToUpper())).Select(m => new AssignmentDTO(m));
        }
        
    }
}
