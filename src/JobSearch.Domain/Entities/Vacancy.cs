namespace JobSearch.Domain.Entities
{
    public class Vacancy : BaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public int JobTypeId { get; set; }
        public int OpportunityTypeId { get; set; }
        public int SeniorityId { get; set; }
        public int AddressId { get; set; }
        public int PhoneId { get; set; }
        public int SalaryId { get; set; }
        public bool IsPremium { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Company Company { get; set; }
        public JobType JobType { get; set; }
        public OpportunityType OpportunityType { get; set; }
        public Seniority Seniority { get; set; }
        public Address Adress { get; set; }
        public Phone Phone { get; set; }
        public Salary Salary { get; set; }

    }
}
