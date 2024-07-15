namespace JobSearch.Models.v1.Vacancy
{
    public class GetVacancyDto
    {
        public int VacancyId { get; set; }
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
    }



}
