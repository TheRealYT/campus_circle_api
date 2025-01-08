using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace campus_circle_api.Model;

[Table("job_application")]
public class JobApplication
{
    public JobApplication()
    {
    }

    public JobApplication(string applicantId, string jobPostId)
    {
        applicant_id = applicantId;
        job_post_id = jobPostId;
    }

    [Key] public string application_id { get; set; } = Guid.NewGuid().ToString();

    [ForeignKey("User")]
    [Column("applicant_id")]
    public string applicant_id { get; set; }

    [JsonIgnore] public virtual User? User { get; set; }

    [ForeignKey("JobPost")]
    [Column("job_post_id")]
    public string job_post_id { get; set; }

    [JsonIgnore] public virtual Message? JobPost { get; set; }

    [JsonIgnore] [Column("date")] public DateTime date { get; set; } = DateTime.Now;
}