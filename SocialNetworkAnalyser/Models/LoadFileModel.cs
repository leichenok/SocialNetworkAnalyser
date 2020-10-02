using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNetworkAnalyser.Models
{
    public class LoadFileModel
    {
        [Display(Name = "Dataset name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field cannot be empty")]
        [MaxLength(20, ErrorMessage = "Length cannot be more than 20 symbols")]
        public string FileName { get; set; }

        [Display(Name = "Dataset source file")]
        [Required(ErrorMessage = "Please upload file")]
        public HttpPostedFileBase SourceFile { get; set; }
    }
}