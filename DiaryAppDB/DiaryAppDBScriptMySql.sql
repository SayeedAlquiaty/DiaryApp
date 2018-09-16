CREATE TABLE IF NOT EXISTS `schools_tb` (
    `school_id`     INT          NOT NULL AUTO_INCREMENT,
    `school_name`   VARCHAR (50) NOT NULL,
    `city_name`     VARCHAR (20) NOT NULL,
    `province_name` VARCHAR (20) NULL,
    `country_name`  VARCHAR (20) NOT NULL,
	`address` 		VARCHAR(50) NOT NULL, 
    `phone` 		VARCHAR(15) NOT NULL,
	`date_created` 	DATE NOT NULL, 
    `date_deleted` 	DATE NULL,
    PRIMARY KEY  (`school_id` )
);

CREATE TABLE IF NOT EXISTS `subsciption_tb` (
	`subscription_id`   INT        NOT NULL AUTO_INCREMENT,
    `school_id`     	INT        NOT NULL,
	`subscriptiontype` 	VARCHAR(1) NOT NULL, 
    `date_created` 		DATE NOT NULL, 
    `date_deleted` 		DATE NULL,
    PRIMARY KEY  (`subscription_id` ),
	CONSTRAINT `FK_subscription_tb_school_tb` FOREIGN KEY (`school_id`) REFERENCES `schools_tb`(`school_id`) 
);

CREATE TABLE IF NOT EXISTS `user_tb`
(
	`user_id` INT NOT NULL AUTO_INCREMENT, 
    `school_id` INT NOT NULL, 
    `user_name` VARCHAR(50) NOT NULL, 
    `password` VARCHAR(50) NOT NULL, 
    `firstname` VARCHAR(50) NOT NULL, 
    `surname` VARCHAR(50) NOT NULL, 
    `type` VARCHAR(1) NOT NULL, 
    `phoneno` VARCHAR(15) NOT NULL, 
    `mobileno` VARCHAR(15) NULL, 
    `address` VARCHAR(100) NULL, 
    `relation` VARCHAR(15) NULL, 
    `remarks` VARCHAR(10) NULL,
	`date_created` DATE NOT NULL, 
    `date_deleted` DATE NULL,
	PRIMARY KEY  (`user_id` ),
	CONSTRAINT `FK_user_tb_school_tb` FOREIGN KEY (`school_id`) REFERENCES `schools_tb`(`school_id`) 
);

CREATE TABLE IF NOT EXISTS `student_tb`
(
	`student_id` INT NOT NULL AUTO_INCREMENT,
	`user_id` INT NOT NULL , 
    `firstname` VARCHAR(50) NOT NULL, 
    `surname` VARCHAR(50) NOT NULL, 
    `rollno` INT NOT NULL,
	`class_id` INT NOT NULL,
	`school_id` INT NOT NULL, 
    `address` VARCHAR(100) NULL, 
    `relation` VARCHAR(15) NULL, 
    `remarks` VARCHAR(10) NULL,
	`date_created` DATE NOT NULL, 
    `date_deleted` DATE NULL,
	PRIMARY KEY  (`student_id` ),
	CONSTRAINT `FK_student_tb_user_tb` FOREIGN KEY (`user_id`) REFERENCES `user_tb`(`user_id`)  
);

CREATE TABLE IF NOT EXISTS `class_tb`
(
	`class_id` INT NOT NULL AUTO_INCREMENT, 
    `class` INT NOT NULL, 
    `section` VARCHAR(1) NOT NULL,
	`school_id` INT NOT NULL,
	`date_created` DATE NOT NULL, 
    `date_deleted` DATE NULL,
	PRIMARY KEY  (`class_id` ),
	CONSTRAINT `FK_class_tb_schools_tb` FOREIGN KEY (`school_id`) REFERENCES `schools_tb`(`school_id`)
);

CREATE TABLE IF NOT EXISTS `classstudents_tb`
(
	`class_id` INT NOT NULL, 
    `student_id` INT NOT NULL,
	`date_created` DATE NOT NULL, 
    `date_deleted` DATE NULL,
	CONSTRAINT `FK_classstudent_tb_class_tb` FOREIGN KEY (`class_id`) REFERENCES `class_tb`(`class_id`)
);

CREATE TABLE IF NOT EXISTS `diary_tb`
(
	`diaryno` VARCHAR(10) NOT NULL,
	`student_id` INT NOT NULL,
	`note_id` INT NOT NULL,
	`date_created` DATE NOT NULL, 
    `date_deleted` DATE NULL,
	PRIMARY KEY  (`diaryno` ),
	CONSTRAINT `FK_diary_tb_student_tb` FOREIGN KEY (`student_id`) REFERENCES `student_tb`(`student_id`)
);

CREATE TABLE IF NOT EXISTS `note_tb`
(
	`note_id` INT NOT NULL AUTO_INCREMENT,
	`user_id` INT NOT NULL, 
    `school_id` INT NOT NULL, 
    `notehealine` VARCHAR(50) NULL,
	`date_created` DATE NOT NULL, 
    `date_deleted` DATE NULL,
	PRIMARY KEY  (`note_id` ),
	CONSTRAINT `FK_note_tb_schools_tb` FOREIGN KEY (`school_id`) REFERENCES `schools_tb`(`school_id`)
);

CREATE TABLE IF NOT EXISTS `notedata_tb`
(
	`note_id` INT NOT NULL, 
    `notetext` TEXT NULL,
	`noteimage` LONGBLOB NULL, 
    `notemedia` LONGBLOB NULL,
	CONSTRAINT `FK_notedata_tb_note_tb` FOREIGN KEY (`note_id`) REFERENCES `note_tb`(`note_id`)
);

CREATE TABLE IF NOT EXISTS `remark_tb`
(
	`remark_id` INT NOT NULL AUTO_INCREMENT,
	`user_id` INT NOT NULL, 
    `note_id` INT NOT NULL,
	`date_created` DATETIME NOT NULL, 
    `date_deleted` DATETIME NULL,
	PRIMARY KEY  (`remark_id` ),
	CONSTRAINT `FK_remark_tb_note_tb` FOREIGN KEY (`note_id`) REFERENCES `note_tb`(`note_id`)
);

CREATE TABLE IF NOT EXISTS `remarkdata_tb`
(
	`remark_id` INT NOT NULL, 
    `remarktext` TEXT NULL,
	`remarkimage` LONGBLOB NULL, 
    `remarkmedia` LONGBLOB NULL,
	CONSTRAINT `FK_remarkdata_tb_remark_tb` FOREIGN KEY (`remark_id`) REFERENCES `remark_tb`(`remark_id`)
);