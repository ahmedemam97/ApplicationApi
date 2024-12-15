

namespace Domain.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            CreatedDate = DateTime.Today;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        //
        public string CreatedById { get; set; }
        public string CreatedByName{ get; set; }
        public DateTime CreatedDate { get; set; }
        //
        public string ModifyById { get; set; }
        public string ModifyByName { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int ModifyCount { get; set; }
    }
}
