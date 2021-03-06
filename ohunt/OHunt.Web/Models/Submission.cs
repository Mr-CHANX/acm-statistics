using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OHunt.Web.Models
{
    [Table("submissions")]
    public class Submission
    {
        /// <summary>
        /// The id of the submission. It should be unique per oj.
        ///
        /// It is used to identify submissions, so newer submission
        /// should have larger id.
        /// </summary>
        [Key]
        [Range(1, long.MaxValue)]
        public long SubmissionId { get; set; }

        /// <summary>
        /// The id of OJs.
        /// </summary>
        [Required]
        [Key]
        public OnlineJudge OnlineJudgeId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(75)]
        public string UserName { get; set; }

        [Required]
        public RunResult Status { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public string ProblemLabel { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
