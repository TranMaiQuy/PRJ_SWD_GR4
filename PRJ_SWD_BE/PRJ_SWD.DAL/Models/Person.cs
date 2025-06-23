using System;
using System.Collections.Generic;

namespace PRJ_SWD.DAL.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string PersonName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public bool Gender { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string? Image { get; set; }

    public int? StaffStatus { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<MedicalExamination> MedicalExaminationCustomers { get; set; } = new List<MedicalExamination>();

    public virtual ICollection<MedicalExamination> MedicalExaminationStaffs { get; set; } = new List<MedicalExamination>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Service> ServicesNavigation { get; set; } = new List<Service>();

    public virtual ICollection<Slider> Sliders { get; set; } = new List<Slider>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
