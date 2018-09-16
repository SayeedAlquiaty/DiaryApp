##CREATE SCHEMA IF NOT EXISTS `ModelHighSchool` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
##Maintian the order of execution##
CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`relationship_tb` (
  `relationship_id` INT NOT NULL AUTO_INCREMENT,
  `relationship_name` VARCHAR(10) NULL,
  `relationship_remarks` VARCHAR(45) NULL,
  `relationship_date_created` DATE NOT NULL,
  `relationship_date_deleted` DATE NULL,
  PRIMARY KEY (`relationship_id`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`parent_tb` (
  `parent_id` INT NOT NULL AUTO_INCREMENT,
  `parent_father_firstname` VARCHAR(45) NOT NULL,
  `parent_father_middlename` VARCHAR(45) NULL,
  `parent_father_surname` VARCHAR(45) NOT NULL,
  `parent_mother_firstname` VARCHAR(45) NOT NULL,
  `parent_mother_middlename` VARCHAR(45) NULL,
  `parent_mother_surname` VARCHAR(45) NOT NULL,
  `parent_gardian_firstname` VARCHAR(45) NULL,
  `parent_gardian_middlename` VARCHAR(45) NULL,
  `parent_gardian_lastname` VARCHAR(45) NULL,
  `parent_phone` VARCHAR(15) NOT NULL,
  `parent_mobile` VARCHAR(15) NULL,
  `reationship_id` INT NOT NULL,
  `parent_date_created` DATE NOT NULL,
  `parent_date_deleted` DATE NULL,
  PRIMARY KEY (`parent_id`),
  INDEX `fk_relationship_id_idx` (`reationship_id` ASC),
  CONSTRAINT `fk_relationship_id`
    FOREIGN KEY (`reationship_id`)
    REFERENCES `ModelHighSchool`.`relationship_tb` (`relationship_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`address_tb` (
  `address_id` INT NOT NULL AUTO_INCREMENT,
  `address_line1` VARCHAR(45) NOT NULL,
  `address_line2` VARCHAR(45) NULL,
  `address_city` VARCHAR(45) NOT NULL,
  `address_state` VARCHAR(45) NOT NULL,
  `address_country` VARCHAR(45) NOT NULL,
  `address_postalcode` VARCHAR(15) NOT NULL,
  `parent_id` INT NOT NULL,
  `address_date_created` DATE NOT NULL,
  `address_date_deleted` DATE NULL,
  PRIMARY KEY (`address_id`),
  INDEX `fk_parent_address_idx` (`parent_id` ASC),
  CONSTRAINT `fk_parent_address`
    FOREIGN KEY (`parent_id`)
    REFERENCES `ModelHighSchool`.`parent_tb` (`parent_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`student_tb` (
  `student_id` INT NOT NULL AUTO_INCREMENT,
  `student_firstname` VARCHAR(45) NOT NULL,
  `student_middlename` VARCHAR(45) NULL,
  `student_surname` VARCHAR(45) NOT NULL,
  `student_dob` DATE NOT NULL,
  `student_phone` VARCHAR(15) NOT NULL,
  `student_mobile` VARCHAR(15) NULL,
  `parent_id` INT NOT NULL,
  `student_date_of_join` DATE NOT NULL,
  `student_status` TINYINT(1) NOT NULL,
  `student_email` VARCHAR(100) NOT NULL,
  `student_password` VARCHAR(45) NOT NULL,
  `student_last-login_date` DATE NOT NULL,
  `student_last_login_IP` VARCHAR(45) NULL,
  `student_date_created` DATE NOT NULL,
  `student_date_deleted` DATE NULL,
  PRIMARY KEY (`student_id`),
  INDEX `fk_parent_child_idx` (`parent_id` ASC),
  CONSTRAINT `fk_parent_child`
    FOREIGN KEY (`parent_id`)
    REFERENCES `ModelHighSchool`.`parent_tb` (`parent_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`teacher_tb` (
  `teacher_id` INT NOT NULL AUTO_INCREMENT,
  `teacher_firstname` VARCHAR(45) NOT NULL,
  `teacher_middlename` VARCHAR(45) NULL,
  `teacher_surname` VARCHAR(45) NOT NULL,
  `teacher_email` VARCHAR(100) NOT NULL,
  `teacher_password` VARCHAR(45) NOT NULL,
  `teacher_dob` DATE NULL,
  `teacher_phone` VARCHAR(15) NOT NULL,
  `teacher_mobile` VARCHAR(15) NULL,
  `teacher_status` TINYINT(1) NOT NULL,
  `teacher_last_login_date` DATE NOT NULL,
  `teacher_last_login_ip` VARCHAR(45) NULL,
  `teacher_date_created` DATE NOT NULL,
  `teacher_date_deleted` DATE NULL,
  PRIMARY KEY (`teacher_id`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`classroom_tb` (
  `classroom_id` INT NOT NULL AUTO_INCREMENT,
  `classroom_year` VARCHAR(45) NOT NULL,
  `classroom_grade` VARCHAR(45) NOT NULL,
  `classroom_section` VARCHAR(45) NULL,
  `classroom_status` TINYINT(1) NOT NULL,
  `classroom_remarks` VARCHAR(100) NULL,
  `classroom_date_created` DATE NOT NULL,
  `classroom_date_deleted` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`classroom_id`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`classteacher_tb` (
  `classteacher_id` INT NOT NULL AUTO_INCREMENT,
  `classroom_id` INT NOT NULL,
  `teacher_id` INT NOT NULL,
  `classteacher_date_created` DATE NOT NULL,
  `classteacher_date_deleted` DATE NULL,
  PRIMARY KEY (`classteacher_id`),
  INDEX `fk_classroom_teacher_idx` (`classroom_id` ASC),
  INDEX `fk_teacher_class_idx` (`teacher_id` ASC),
  CONSTRAINT `fk_classroom_teacher`
    FOREIGN KEY (`classroom_id`)
    REFERENCES `ModelHighSchool`.`classroom_tb` (`classroom_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_teacher_class`
    FOREIGN KEY (`teacher_id`)
    REFERENCES `ModelHighSchool`.`teacher_tb` (`teacher_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`classroomstudent_tb` (
  `classroomstudent_id` INT NOT NULL AUTO_INCREMENT,
  `classroom_id` INT NOT NULL,
  `student_id` INT NOT NULL,
  `classroomstudent_date_created` DATE NOT NULL,
  `classroomstudent_date_deleted` DATE NULL,
  PRIMARY KEY (`classroomstudent_id`),
  INDEX `fk_classroom_student_idx` (`classroom_id` ASC),
  CONSTRAINT `fk_classroom_student`
    FOREIGN KEY (`classroom_id`)
    REFERENCES `ModelHighSchool`.`classroom_tb` (`classroom_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`attendance_tb` (
  `attendance_id` INT NOT NULL AUTO_INCREMENT,
  `attendance_date` DATE NOT NULL,
  `student_id` INT NOT NULL,
  `attendance_status` TINYINT(1) NOT NULL,
  `attendance_remarks` VARCHAR(100) NULL,
  `attendance_date_created` DATE NOT NULL,
  `attendance_date_deleted` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`attendance_id`),
  INDEX `fk_student_attendence_idx` (`student_id` ASC),
  CONSTRAINT `fk_student_attendence`
    FOREIGN KEY (`student_id`)
    REFERENCES `ModelHighSchool`.`student_tb` (`student_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`studentdiary_tb` (
  `studentdiary_id` INT NOT NULL AUTO_INCREMENT,
  `student_id` INT NOT NULL,
  `teacher_id` INT NOT NULL,
  `studentdiary_date` DATE NOT NULL,
  `studentdiary_notes` VARCHAR(200) NOT NULL,
  `studentdiary_statusl` TINYINT(1) NOT NULL,
  `studentdiary_date_created` DATE NOT NULL,
  `studentdiary_date_deleted` DATE NULL,
  PRIMARY KEY (`studentdiary_id`),
  INDEX `fk_student_diary_idx` (`student_id` ASC),
  CONSTRAINT `fk_student_diary`
    FOREIGN KEY (`student_id`)
    REFERENCES `ModelHighSchool`.`student_tb` (`student_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`subjectcatagory_tb` (
  `subjectcatagory_id` INT NOT NULL AUTO_INCREMENT,
  `subjectcatagory_name` VARCHAR(45) NOT NULL,
  `subjectcatagory_date_created` DATE NOT NULL,
  `subjectcatagory_date_deleted` DATE NULL,
  PRIMARY KEY (`subjectcatagory_id`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`subject_tb` (
  `subject_id` INT NOT NULL AUTO_INCREMENT,
  `subject_name` VARCHAR(45) NOT NULL,
  `subjectcatagory_id` INT NOT NULL,
  `subject_date_created` DATE NOT NULL,
  `subject_date_deleted` DATE NULL,
  PRIMARY KEY (`subject_id`),
  INDEX `fk_subjectcatagory_id_idx` (`subjectcatagory_id` ASC),
  CONSTRAINT `fk_subjectcatagory_id`
    FOREIGN KEY (`subjectcatagory_id`)
    REFERENCES `ModelHighSchool`.`subjectcatagory_tb` (`subjectcatagory_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`faculty_tb` (
  `faculty_id` INT NOT NULL AUTO_INCREMENT,
  `subject_id` INT NOT NULL,
  `teacher_id` INT NOT NULL,
  `classroom_id` INT NOT NULL,
  `faculty_date_created` DATE NOT NULL,
  `faculty_date_deleted` DATE NULL,
  PRIMARY KEY (`faculty_id`),
  INDEX `fk_teacher_faculty_idx` (`teacher_id` ASC),
  INDEX `fk_subject_faculty_idx` (`subject_id` ASC),
  INDEX `fk_classroom_faculty_idx` (`classroom_id` ASC),
  CONSTRAINT `fk_teacher_faculty`
    FOREIGN KEY (`teacher_id`)
    REFERENCES `ModelHighSchool`.`teacher_tb` (`teacher_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_subject_faculty`
    FOREIGN KEY (`subject_id`)
    REFERENCES `ModelHighSchool`.`subject_tb` (`subject_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_classroom_faculty`
    FOREIGN KEY (`classroom_id`)
    REFERENCES `ModelHighSchool`.`classroom_tb` (`classroom_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`examtype_tb` (
  `examtype_id` INT NOT NULL AUTO_INCREMENT,
  `examtype_name` VARCHAR(45) NOT NULL,
  `examtype_desc` VARCHAR(100) NULL,
  `examtype_date_created` DATE NOT NULL,
  `examtype_date_deleted` DATE NULL,
  PRIMARY KEY (`examtype_id`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`exam_tb` (
  `exam_id` INT NOT NULL AUTO_INCREMENT,
  `examtype_id` INT NOT NULL,
  `exam_startdate` DATE NOT NULL,
  `exam_desc` VARCHAR(100) NULL,
  `exam_date_created` DATE NOT NULL,
  `exam_date_deleted` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`exam_id`),
  INDEX `fk_examtype_id_idx` (`examtype_id` ASC),
  CONSTRAINT `fk_examtype_id`
    FOREIGN KEY (`examtype_id`)
    REFERENCES `ModelHighSchool`.`examtype_tb` (`examtype_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ModelHighSchool`.`examresult_tb` (
  `examresult_id` INT NOT NULL AUTO_INCREMENT,
  `exam_id` INT NOT NULL,
  `student_id` INT NOT NULL,
  `subject_id` INT NOT NULL,
  `examresult_marks` INT NOT NULL,
  `examresult_grade` VARCHAR(2) NOT NULL,
  `examresult_desc` VARCHAR(45) NULL,
  `examresult_date_created` DATE NOT NULL,
  `examresult_date_deleted` DATE NULL,
  PRIMARY KEY (`examresult_id`),
  INDEX `fk_exam_examresult_idx` (`exam_id` ASC),
  INDEX `fk_student_examresult_idx` (`student_id` ASC),
  INDEX `fk_subject_examresult_idx` (`subject_id` ASC),
  CONSTRAINT `fk_exam_examresult`
    FOREIGN KEY (`exam_id`)
    REFERENCES `ModelHighSchool`.`exam_tb` (`exam_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_student_examresult`
    FOREIGN KEY (`student_id`)
    REFERENCES `ModelHighSchool`.`student_tb` (`student_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_subject_examresult`
    FOREIGN KEY (`subject_id`)
    REFERENCES `ModelHighSchool`.`subject_tb` (`subject_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;