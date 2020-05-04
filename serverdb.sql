CREATE TABLE IF NOT EXISTS `customer_astcrm` (
  `customer_astcrm_id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL,
  `license_type` int(11) NOT NULL default '1',
  `license_count_first` int(11) NOT NULL default '0',
  `license_count_current` int(11) NOT NULL default '0',
  `comment` text,
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`customer_astcrm_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

CREATE TABLE IF NOT EXISTS `customer_astcrm_log` (
  `customer_astcrm_log_id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL,
  `from_ip` int(11) NOT NULL default '1',
  `log_text` text,
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`customer_astcrm_log_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;
