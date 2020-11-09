﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchitecture.Domain.Models
{

    public class OneSignalApp
    {
        public string id { get; set; }

        [Required(ErrorMessage = "Please Enter the name of App!")]
        [Display(Name = "App Title")]
        public string name { get; set; }
        public string gcm_key { get; set; }
        public string chrome_key { get; set; }
        public string chrome_web_key { get; set; }
        public string chrome_web_origin { get; set; }
        public string chrome_web_gcm_sender_id { get; set; }
        public string chrome_web_default_notification_icon { get; set; }
        public string chrome_web_sub_domain { get; set; }
        public string apns_env { get; set; }
        public string apns_certificates { get; set; }
        public string safari_apns_certificate { get; set; }
        public string safari_site_origin { get; set; }
        public string safari_push_id { get; set; }
        public string safari_icon_16_16 { get; set; }
        public string safari_icon_32_32 { get; set; }
        public string safari_icon_64_64 { get; set; }
        public string safari_icon_128_128 { get; set; }
        public string safari_icon_256_256 { get; set; }
        public string site_name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int players { get; set; }
        public int messageable_players { get; set; }
        public string basic_auth_key { get; set; }
        public bool additional_data_is_root_payload { get; set; }
    }

}
