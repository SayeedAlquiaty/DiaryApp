
CREATE TABLE relationship_tb (
  relationship_id INT NOT NULL,
  relationship_name VARCHAR(10) NOT NULL,
  relationship_remarks VARCHAR(45) NULL,
  relationship_date_created DATE NOT NULL,
  relationship_date_deleted DATE NULL,
  PRIMARY KEY (relationship_name))