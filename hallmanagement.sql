-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Mar 24, 2017 at 11:50 PM
-- Server version: 10.1.19-MariaDB
-- PHP Version: 7.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hallmanagement`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `addApplicationInfo` (IN `fName` VARCHAR(50), IN `lName` VARCHAR(50), IN `roll` VARCHAR(10), IN `ltCGPA` DOUBLE, IN `did` INT(11), IN `fatherName` VARCHAR(128), IN `motherName` VARCHAR(128), IN `batch` VARCHAR(10), IN `birthdate` DATE, IN `sex` TEXT, IN `preAddress` TEXT, IN `perAddress` TEXT, IN `lgName` VARCHAR(128), IN `lgAddress` TEXT, IN `lgPhoneNo` LONGTEXT, IN `phoneNo` LONGTEXT, IN `bGroup` TEXT, IN `hid` INT(11), IN `email` VARCHAR(256), IN `fatherOccupation` VARCHAR(256), IN `fatherYearlyIncome` VARCHAR(15), IN `motherOccupation` VARCHAR(256), IN `motherYearlyIncome` VARCHAR(15), IN `mStatus` TEXT, IN `causesOfApplication` TEXT)  NO SQL
INSERT INTO application VALUES(null,fName,lName,roll,ltCGPA,did,fatherName,fatherOccupation,fatherYearlyIncome,motherName,motherOccupation,motherYearlyIncome,batch,birthdate,sex,bGroup,mStatus,causesOfApplication,hid,email,preAddress,perAddress,lgName,lgAddress,lgPhoneNo,phoneNo)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `addDisciplineAllotedSeat` (IN `disciplineName` VARCHAR(128), IN `allotedSeat` VARCHAR(10), IN `hid` INT(11))  NO SQL
INSERT INTO discipline VALUES(null,hid,disciplineName,allotedSeat)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `addHallAuthority` (IN `uid` VARCHAR(128), IN `hid` INT(11), IN `designation` VARCHAR(50), IN `position` VARCHAR(50))  NO SQL
INSERT INTO hallauthority VALUES(null,uid,hid,designation,position)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `addHallRoom` (IN `hName` VARCHAR(256), IN `totalRoomNO` VARCHAR(10), IN `totalSeatNo` VARCHAR(10))  NO SQL
INSERT INTO hall VALUES(null,hName,totalRoomNo,totalSeatNo)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `addNews` (IN `title` TEXT, IN `body` LONGTEXT)  NO SQL
INSERT INTO news VALUES(null,title,body)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `addNotice` (IN `title` TEXT, IN `body` LONGTEXT)  NO SQL
INSERT INTO notice VALUES(null,title,body)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `addRoomSeat` (IN `roomNo` VARCHAR(10), IN `seatNumber` VARCHAR(10), IN `hid` INT(11))  NO SQL
INSERT INTO room VALUES(null,hid,roomNo,seatNumber)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `addStudent` (IN `uid` VARCHAR(128), IN `hid` INT(11), IN `aid` INT(11), IN `did` INT(11), IN `roll` VARCHAR(10), IN `batch` VARCHAR(10), IN `rid` INT(11))  NO SQL
INSERT INTO student VALUES(null,uid,hid,aid,did,roll,batch,rid)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countApplicationEmail` (IN `email` VARCHAR(256))  NO SQL
SELECT COUNT(application.id) FROM application WHERE application.Email=email$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countApplicationNo` (IN `aid` INT(11))  NO SQL
SELECT COUNT(application.id) FROM application WHERE application.id=aid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countApplicationRollNo` (IN `roll` VARCHAR(10))  NO SQL
SELECT COUNT(application.id) FROM application WHERE application.rollNo=roll$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countDiscipline` (IN `dName` VARCHAR(128), IN `hid` INT(11))  NO SQL
SELECT COUNT(discipline.id) FROM discipline WHERE discipline.disciplineName=dName AND discipline.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countDisciplineUnallotedSeatByHId` (IN `hid` INT(11))  NO SQL
SELECT hall.totalSeatNo-SUM(discipline.allotedSeatNo) FROM hall,discipline WHERE hall.id=hid AND discipline.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countEditApplicationEmail` (IN `email` VARCHAR(256), IN `aid` INT(11))  NO SQL
SELECT COUNT(application.id) FROM application WHERE application.Email=email AND application.id NOT IN(aid)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countEditApplicationRollNo` (IN `roll` VARCHAR(10), IN `aid` INT(11))  NO SQL
SELECT COUNT(application.id) FROM application WHERE application.rollNo=roll AND application.id NOT IN(aid)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countEditHallStudentByHUId` (IN `hid` INT(11), IN `uid` VARCHAR(128))  NO SQL
SELECT COUNT(student.Id) FROM student WHERE student.hallId=hid AND student.userId NOT IN(uid)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countEditRollNo` (IN `roll` VARCHAR(10), IN `uid` VARCHAR(128))  NO SQL
SELECT COUNT(student.Id) FROM student WHERE student.rollNo=roll AND student.userId NOT IN(uid)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countEditStudentApplication` (IN `aid` INT(11), IN `uid` VARCHAR(128))  NO SQL
SELECT COUNT(student.Id) FROM student WHERE student.applicationId=aid AND student.userId NOT IN(uid)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countHallName` (IN `hName` VARCHAR(256))  NO SQL
SELECT COUNT(hall.id) FROM hall WHERE hall.hallName=hName$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countHallStudentByHId` (IN `hid` INT(11))  NO SQL
SELECT COUNT(student.id) FROM student WHERE student.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countManageEmail` (IN `email` VARCHAR(256), IN `uid` VARCHAR(128))  NO SQL
SELECT COUNT(users.Id) FROM users WHERE users.Email=email AND users.Id NOT IN(uid)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countRegisterEmail` (IN `email` VARCHAR(256))  NO SQL
SELECT COUNT(users.Id) FROM users WHERE users.Email=email$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countRollNo` (IN `roll` VARCHAR(10))  NO SQL
SELECT COUNT(student.id) FROM student WHERE student.rollNo=roll$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countRoomNo` (IN `rNo` VARCHAR(10), IN `hid` INT(11))  NO SQL
SELECT COUNT(room.id) FROM room WHERE room.roomNo=rNo AND room.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countRoomUnallottedSeatByHId` (IN `hid` INT(11))  NO SQL
SELECT hall.totalSeatNo-SUM(room.seatNumber) FROM hall,room WHERE hall.id=hid AND room.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countStudentApplication` (IN `aid` INT(11))  NO SQL
SELECT COUNT(student.id) FROM student WHERE student.applicationId=aid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countStudentSeatByHDId` (IN `hid` INT(11), IN `did` INT(11))  NO SQL
SELECT COUNT(student.id) FROM student WHERE student.hallId=hid AND student.disciplineId=did$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `countStudentSeatByHRId` (IN `hid` INT(11), IN `rid` INT(11))  NO SQL
SELECT COUNT(student.id) FROM student WHERE student.hallId=hid AND student.roomId=rid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteApplicationByAId` (IN `aid` INT(11))  NO SQL
DELETE FROM application WHERE application.id=aid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteDisciplineByDId` (IN `did` INT(11))  NO SQL
DELETE FROM discipline WHERE discipline.id=did$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteHAbyHAUId` (IN `uid` VARCHAR(128))  NO SQL
DELETE FROM users WHERE users.Id=uid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteHallByHId` (IN `hid` INT(11))  NO SQL
DELETE FROM hall WHERE hall.id=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteNewsById` (IN `newsId` INT(11))  NO SQL
DELETE FROM news WHERE news.id=newsId$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteNoticeById` (IN `noticeId` INT(11))  NO SQL
DELETE FROM notice WHERE notice.id=noticeId$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteRoomByRId` (IN `rid` INT(11))  NO SQL
DELETE FROM room WHERE room.id=rid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteStudentBySUId` (IN `uid` VARCHAR(128))  NO SQL
DELETE FROM users WHERE users.Id=uid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteUserByUId` (IN `uid` VARCHAR(128))  NO SQL
DELETE FROM users WHERE users.Id=uid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAcceptedApplicationDetail` ()  NO SQL
SELECT applicationdetail.id,applicationdetail.FirstName,applicationdetail.LastName,applicationdetail.rollNo,applicationdetail.lastTermCGPA,applicationdetail.disciplineName,applicationdetail.fathersName,applicationdetail.fathersOccupation,applicationdetail.fathersYearlyIncome,applicationdetail.mothersName,applicationdetail.mothersOccupation,applicationdetail.mothersYearlyIncome,applicationdetail.batch,applicationdetail.birthdate,applicationdetail.sex,applicationdetail.bloodGroup,applicationdetail.maritalStatus,applicationdetail.causesOfApplication,applicationdetail.hallName,applicationdetail.Email,applicationdetail.presentAddress,applicationdetail.permanentAddress,applicationdetail.localGuardianName,applicationdetail.localGuardianAddress,applicationdetail.localGuardianPhoneNo,applicationdetail.PhoneNumber FROM applicationdetail,student WHERE student.applicationId=applicationdetail.id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllApplicationDetail` ()  NO SQL
SELECT * FROM applicationdetail$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllBatchName` ()  NO SQL
SELECT DISTINCT(applicationdetail.batch) FROM applicationdetail$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllDiscipline` (IN `hid` INT(11))  NO SQL
SELECT discipline.id,discipline.disciplineName FROM discipline WHERE discipline.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllDisciplineInfoByHId` (IN `hid` INT(11))  NO SQL
SELECT hall.hallName,discipline.id, discipline.disciplineName,discipline.allotedSeatNo FROM hall,discipline WHERE hall.id=hid AND discipline.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllDisciplineNameByHallName` (IN `HName` VARCHAR(256))  NO SQL
SELECT discipline.disciplineName FROM discipline WHERE (SELECT hall.hallName FROM hall WHERE hall.id=discipline.hallId)=HName$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllDistinctBatch` ()  NO SQL
SELECT DISTINCT(student.batch) FROM student$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllHADetail` ()  NO SQL
SELECT * FROM hallauthoritydetail$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllHall` ()  NO SQL
SELECT hall.id, hall.hallName FROM hall$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllHallInfo` ()  NO SQL
SELECT hall.id,hall.hallName,hall.totalRoomNo,hall.totalSeatNo FROM hall$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllHallName` ()  NO SQL
SELECT hall.hallName FROM hall$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllNews` ()  NO SQL
SELECT news.id,news.title FROM news$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllNotice` ()  NO SQL
SELECT notice.id,notice.title FROM notice$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllRoomInfoByHId` (IN `hid` INT(11))  NO SQL
SELECT hall.hallName,room.id, room.roomNo,room.seatNumber FROM hall,room WHERE hall.id=hid AND room.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllStudentDetail` ()  NO SQL
SELECT * FROM studentdetail$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllUnApplicationDetail` ()  NO SQL
SELECT * FROM unacceptedapplication$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByAddress` (IN `address` TEXT)  NO SQL
SELECT * FROM applicationdetail WHERE applicationdetail.presentAddress LIKE address OR applicationdetail.permanentAddress LIKE address$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByAId` (IN `aid` INT(11))  NO SQL
SELECT * FROM applicationdetail WHERE applicationdetail.id=aid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByBatch` (IN `batch` VARCHAR(10))  NO SQL
SELECT * FROM applicationdetail WHERE applicationdetail.batch=batch$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByBGroup` (IN `BGroup` TEXT)  NO SQL
SELECT * FROM applicationdetail WHERE applicationdetail.bloodGroup=BGroup$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByDesc` ()  NO SQL
SELECT * FROM applicationdetail ORDER BY applicationdetail.id DESC$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByHall` (IN `HName` VARCHAR(256))  NO SQL
SELECT * FROM applicationdetail WHERE applicationdetail.hallName=HName$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByHallDiscipline` (IN `HName` VARCHAR(256), IN `DName` VARCHAR(128))  NO SQL
SELECT * FROM applicationdetail WHERE applicationdetail.hallName=HName AND applicationdetail.disciplineName=DName$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByName` (IN `name` VARCHAR(50))  NO SQL
SELECT * FROM applicationdetail WHERE applicationdetail.FirstName LIKE name OR applicationdetail.LastName LIKE name$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByPhoneNo` (IN `phoneNo` LONGTEXT)  NO SQL
SELECT * FROM applicationdetail WHERE applicationdetail.PhoneNumber LIKE phoneNo$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByRange100` ()  NO SQL
SELECT * FROM applicationdetail ORDER BY applicationdetail.id ASC LIMIT 2$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByRange150` ()  NO SQL
SELECT * FROM applicationdetail ORDER BY applicationdetail.id ASC LIMIT 3$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByRange200` ()  NO SQL
SELECT * FROM applicationdetail ORDER BY applicationdetail.id ASC LIMIT 4$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByRange50` ()  NO SQL
SELECT * FROM applicationdetail ORDER BY applicationdetail.id ASC LIMIT 1$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationByRollNo` (IN `rollNo` VARCHAR(10))  NO SQL
SELECT * FROM applicationdetail WHERE applicationdetail.rollNo=rollNo$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getApplicationDetailsByAId` (IN `aid` INT(11))  NO SQL
SELECT * FROM application WHERE application.id=aid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getCurrentApplicationId` ()  NO SQL
SELECT MAX(application.id)+1 AS currentApplicationId FROM application$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getDesignationByUId` (IN `uid` VARCHAR(128))  NO SQL
SELECT hallauthority.designation FROM hallauthority WHERE hallauthority.userId=uid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getDisciplineByHDId` (IN `hid` INT(11), IN `did` INT(11))  NO SQL
SELECT discipline.disciplineName FROM discipline WHERE discipline.id=did AND discipline.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getDisciplineTotalSeatByHDId` (IN `hid` INT(11), IN `did` INT(11))  NO SQL
SELECT discipline.allotedSeatNo FROM discipline WHERE discipline.hallId=hid AND discipline.id=did$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getDistinctDisciplineId` (IN `hid` INT(11))  NO SQL
SELECT DISTINCT(discipline.id) AS distDisciplineId FROM discipline WHERE discipline.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getDistinctRoomId` (IN `hid` INT(11))  NO SQL
SELECT DISTINCT(room.id) AS distRoomId FROM room WHERE room.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHAByAddress` (IN `address` TEXT)  NO SQL
SELECT * FROM hallauthoritydetail WHERE hallauthoritydetail.Address LIKE address$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHAByDesignation` (IN `designation` VARCHAR(50))  NO SQL
SELECT * FROM hallauthoritydetail WHERE hallauthoritydetail.designation=designation$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHAByHall` (IN `HName` VARCHAR(256))  NO SQL
SELECT * FROM hallauthoritydetail WHERE hallauthoritydetail.hallName=HName$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHAByName` (IN `name` VARCHAR(50))  NO SQL
SELECT * FROM hallauthoritydetail WHERE hallauthoritydetail.FirstName LIKE name OR hallauthoritydetail.LastName LIKE name$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHAByPhoneNo` (IN `phoneNo` LONGTEXT)  NO SQL
SELECT * FROM hallauthoritydetail WHERE hallauthoritydetail.PhoneNumber LIKE phoneNo$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHAByPosition` (IN `position` VARCHAR(50))  NO SQL
SELECT * FROM hallauthoritydetail WHERE hallauthoritydetail.position=position$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHAByRange100` ()  NO SQL
SELECT * FROM hallauthoritydetail LIMIT 2$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHAByRange150` ()  NO SQL
SELECT * FROM hallauthoritydetail LIMIT 3$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHAByRange200` ()  NO SQL
SELECT * FROM hallauthoritydetail LIMIT 4$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHAByRange50` ()  NO SQL
SELECT * FROM hallauthoritydetail LIMIT 1$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHAByUName` (IN `UName` VARCHAR(128))  NO SQL
SELECT * FROM hallauthoritydetail WHERE hallauthoritydetail.UserName=UName$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHallAuthorityInfo` (IN `uid` VARCHAR(128))  NO SQL
SELECT hallauthority.designation,hallauthority.position,hall.hallName FROM hallauthority,hall WHERE hallauthority.userId=uid AND hall.id=hallauthority.hallId$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHallTotalSeat` (IN `hid` INT(11))  NO SQL
SELECT hall.totalSeatNo FROM hall WHERE hall.id=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getHARegistrationInfoByUId` (IN `uid` VARCHAR(128))  NO SQL
SELECT users.UserName,users.FirstName,users.LastName,users.fathersName,users.mothersName,users.birthdate,users.sex,users.Email,users.Address,users.PhoneNumber,hallauthority.designation,hallauthority.position,hallauthority.hallId FROM users,hallauthority WHERE users.Id=uid AND hallauthority.userId=users.Id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getLatestNews` ()  NO SQL
SELECT news.id,news.title FROM news ORDER BY news.id DESC LIMIT 7$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getLatestNotice` ()  NO SQL
SELECT notice.id,notice.title FROM notice ORDER BY notice.id DESC LIMIT 7$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getNewsById` (IN `newsId` INT(11))  NO SQL
SELECT news.title,news.description FROM news WHERE news.id=newsId$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getNoticeById` (IN `noticeId` INT(11))  NO SQL
SELECT notice.title,notice.description FROM notice WHERE notice.id=noticeId$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getNumberOfHall` ()  NO SQL
SELECT COUNT(hall.id) FROM hall$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getRegistrationInfoByAId` (IN `aid` INT(11))  NO SQL
SELECT application.id as appId,application.FirstName,application.LastName,application.rollNo,application.disciplineId,application.fathersName,application.mothersName,application.batch,application.birthdate,application.sex,application.hallId,application.Email,application.presentAddress,application.PhoneNumber FROM application WHERE application.id=aid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getRegistrationInfoByUId` (IN `uid` VARCHAR(128))  NO SQL
SELECT users.UserName,users.FirstName,users.LastName,users.fathersName,users.mothersName,users.sex,users.birthdate,student.hallId,discipline.disciplineName,room.roomNo,student.rollNo,student.batch,student.applicationId,users.Email,users.PhoneNumber,users.Address FROM users,student,room,discipline WHERE users.Id=uid AND student.userId=users.Id AND student.roomId=room.id AND student.disciplineId=discipline.id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getRoomNoByHRId` (IN `hid` INT(11), IN `rid` INT(11))  NO SQL
SELECT room.roomNo FROM room WHERE room.hallId=hid AND room.id=rid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getRoomTotalSeatByHRId` (IN `hid` INT(11), IN `rid` INT(11))  NO SQL
SELECT room.seatNumber FROM room WHERE room.id=rid AND room.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getSexByUId` (IN `uid` VARCHAR(128))  NO SQL
SELECT users.sex FROM users WHERE users.Id=uid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getSIdAndDisciplineIdByHId` (IN `hid` INT(11))  NO SQL
SELECT student.id as sId, student.disciplineId AS sDisciplineId FROM student WHERE student.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getSIdAndSRoomIdByHId` (IN `hid` INT(11))  NO SQL
SELECT student.id AS sId,student.roomId AS sRoomId FROM student WHERE student.hallId=hid ORDER BY sRoomId ASC$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByAddress` (IN `address` TEXT)  NO SQL
SELECT * FROM studentdetail WHERE studentdetail.Address LIKE address$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByAId` (IN `aid` INT(11))  NO SQL
SELECT * FROM studentdetail WHERE studentdetail.applicationId=aid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByBatch` (IN `batch` VARCHAR(10))  NO SQL
SELECT * FROM studentdetail WHERE studentdetail.batch=batch$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByBGroup` (IN `BGroup` TEXT)  NO SQL
SELECT * FROM studentdetail WHERE studentdetail.bloodGroup=BGroup$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByHall` (IN `HName` VARCHAR(256))  NO SQL
SELECT * FROM studentdetail WHERE studentdetail.hallName=HName$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByHallDiscipline` (IN `HName` VARCHAR(256), IN `DName` VARCHAR(128))  NO SQL
SELECT * FROM studentdetail WHERE studentdetail.hallName=HName AND studentdetail.disciplineName=DName$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByName` (IN `name` VARCHAR(50))  NO SQL
SELECT * FROM studentdetail WHERE studentdetail.FirstName LIKE name OR studentdetail.LastName LIKE name$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByPhoneNo` (IN `phoneNo` LONGTEXT)  NO SQL
SELECT * FROM studentdetail WHERE studentdetail.PhoneNumber LIKE phoneNo$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByRange100` ()  NO SQL
SELECT * FROM studentdetail ORDER BY studentdetail.applicationId ASC LIMIT 2$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByRange150` ()  NO SQL
SELECT * FROM studentdetail ORDER BY studentdetail.applicationId ASC LIMIT 3$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByRange200` ()  NO SQL
SELECT * FROM studentdetail ORDER BY studentdetail.applicationId ASC LIMIT 4$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByRange50` ()  NO SQL
SELECT * FROM studentdetail ORDER BY studentdetail.applicationId ASC LIMIT 1$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByRollNo` (IN `rollNo` VARCHAR(10))  NO SQL
SELECT * FROM studentdetail WHERE studentdetail.rollNo=rollNo$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByRoomHall` (IN `HName` VARCHAR(256), IN `roomNo` VARCHAR(10))  NO SQL
SELECT * FROM studentdetail WHERE studentdetail.hallName=HName AND studentdetail.roomNo=roomNo$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentByUName` (IN `UName` VARCHAR(256))  NO SQL
SELECT * FROM studentdetail WHERE studentdetail.UserName=UName$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getStudentInfo` (IN `uid` VARCHAR(128))  NO SQL
SELECT  hall.hallName, discipline.disciplineName,student.rollNo,student.batch,room.roomNo, application.bloodGroup,application.localGuardianName,application.localGuardianAddress,application.localGuardianPhoneNo FROM student,hall,discipline,application,room WHERE student.userId=uid AND student.hallId=hall.id AND student.disciplineId=discipline.id AND student.applicationId=application.id AND student.roomId=room.id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getTotalSeatAndDisciplineAllotedSeat` (IN `hid` INT(11))  NO SQL
SELECT hall.totalSeatNo,SUM(discipline.allotedSeatNo) AS disciplineTotalSeat FROM hall,discipline WHERE discipline.hallId=hid AND hall.id=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getTotalSeatAndRoomAllotedSeat` (IN `hid` INT(11))  NO SQL
SELECT hall.totalSeatNo,SUM(room.seatNumber) AS roomTotalSeat FROM hall,room WHERE hall.id=hid AND room.hallId=hid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUIdByAId` (IN `aid` INT(11))  NO SQL
SELECT student.userId FROM student WHERE student.applicationId=aid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnacceptedApplicationDetail` ()  NO SQL
SELECT applicationdetail.id,applicationdetail.FirstName,applicationdetail.LastName,applicationdetail.rollNo,applicationdetail.lastTermCGPA,applicationdetail.disciplineName,applicationdetail.fathersName,applicationdetail.fathersOccupation,applicationdetail.fathersYearlyIncome,applicationdetail.mothersName,applicationdetail.mothersOccupation,applicationdetail.mothersYearlyIncome,applicationdetail.batch,applicationdetail.birthdate,applicationdetail.sex,applicationdetail.bloodGroup,applicationdetail.maritalStatus,applicationdetail.causesOfApplication,applicationdetail.hallName,applicationdetail.Email,applicationdetail.presentAddress,applicationdetail.permanentAddress,applicationdetail.localGuardianName,applicationdetail.localGuardianAddress,applicationdetail.localGuardianPhoneNo,applicationdetail.PhoneNumber FROM applicationdetail WHERE applicationdetail.id NOT IN(SELECT student.applicationId FROM student)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByAddress` (IN `address` TEXT)  NO SQL
SELECT * FROM unacceptedapplication WHERE unacceptedapplication.presentAddress LIKE address OR unacceptedapplication.permanentAddress LIKE address$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByAId` (IN `aid` INT(11))  NO SQL
SELECT * FROM unacceptedapplication WHERE unacceptedapplication.id=aid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByBatch` (IN `batch` VARCHAR(10))  NO SQL
SELECT * FROM unacceptedapplication WHERE unacceptedapplication.batch=batch$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByBGroup` (IN `BGroup` TEXT)  NO SQL
SELECT * FROM unacceptedapplication WHERE unacceptedapplication.bloodGroup=BGroup$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByDesc` ()  NO SQL
SELECT * FROM unacceptedapplication ORDER BY unacceptedapplication.id DESC$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByHall` (IN `HName` VARCHAR(256))  NO SQL
SELECT * FROM unacceptedapplication WHERE unacceptedapplication.hallName=HName$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByHallDiscipline` (IN `HName` VARCHAR(256), IN `DName` VARCHAR(128))  NO SQL
SELECT * FROM unacceptedapplication WHERE unacceptedapplication.hallName=HName AND unacceptedapplication.disciplineName=DName$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByName` (IN `name` VARCHAR(50))  NO SQL
SELECT * FROM unacceptedapplication WHERE unacceptedapplication.FirstName LIKE name OR unacceptedapplication.LastName LIKE name$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByPhoneNo` (IN `phoneNo` LONGTEXT)  NO SQL
SELECT * FROM unacceptedapplication WHERE unacceptedapplication.PhoneNumber LIKE phoneNo$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByRange100` ()  NO SQL
SELECT * FROM unacceptedapplication ORDER BY unacceptedapplication.id ASC LIMIT 2$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByRange150` ()  NO SQL
SELECT * FROM unacceptedapplication ORDER BY unacceptedapplication.id ASC LIMIT 3$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByRange200` ()  NO SQL
SELECT * FROM unacceptedapplication ORDER BY unacceptedapplication.id ASC LIMIT 4$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByRange50` ()  NO SQL
SELECT * FROM unacceptedapplication ORDER BY unacceptedapplication.id ASC LIMIT 1$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getUnApplicationByRollNo` (IN `rollNo` VARCHAR(10))  NO SQL
SELECT * FROM unacceptedapplication WHERE unacceptedapplication.rollNo=rollNo$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `updateApplicationInfo` (IN `firstName` VARCHAR(50), IN `lastName` VARCHAR(50), IN `roll` VARCHAR(10), IN `ltCGPA` DOUBLE, IN `did` INT(11), IN `fathersName` VARCHAR(128), IN `fathersOccupation` VARCHAR(256), IN `fathersYearlyIncome` VARCHAR(15), IN `mothersName` VARCHAR(128), IN `mothersOccupation` VARCHAR(256), IN `mothersYearlyIncome` VARCHAR(15), IN `batch` VARCHAR(10), IN `birthdate` DATE, IN `sex` TEXT, IN `bloodGroup` TEXT, IN `maritalStatus` TEXT, IN `causesOfApplication` TEXT, IN `hid` INT(11), IN `email` VARCHAR(256), IN `preAddress` TEXT, IN `perAddress` TEXT, IN `localGuardianName` VARCHAR(128), IN `localGuardianAddress` TEXT, IN `localGuardianPhoneNo` LONGTEXT, IN `phoneNo` LONGTEXT, IN `aid` INT(11))  NO SQL
UPDATE application SET application.FirstName=firstName,application.LastName=lastName,application.rollNo=roll,application.lastTermCGPA=ltCGPA,application.disciplineId=did,application.fathersName=fathersName,application.fathersOccupation=fathersOccupation,application.fathersYearlyIncome=fathersYearlyIncome,application.mothersName=mothersName,application.mothersOccupation=mothersOccupation,application.mothersYearlyIncome=mothersYearlyIncome,application.batch=batch,application.birthdate=birthdate,application.sex=sex,application.bloodGroup=bloodGroup,application.maritalStatus=maritalStatus,application.causesOfApplication=causesOfApplication,application.hallId=hid,application.Email=email,application.presentAddress=preAddress,application.permanentAddress=perAddress,application.localGuardianName=localGuardianName,application.localGuardianAddress=localGuardianAddress,application.localGuardianPhoneNo=localGuardianPhoneNo,application.PhoneNumber=phoneNo WHERE application.id=aid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `updateDesignationByUId` (IN `uid` VARCHAR(128), IN `designation` VARCHAR(50))  NO SQL
UPDATE hallauthority SET hallauthority.designation=designation WHERE hallauthority.userId=uid$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `updateHAInfo` (IN `firstName` VARCHAR(50), IN `lastName` VARCHAR(50), IN `designation` VARCHAR(50), IN `position` VARCHAR(50), IN `fatherName` VARCHAR(128), IN `motherName` VARCHAR(128), IN `birthdate` DATE, IN `sex` TEXT, IN `hid` INT(11), IN `email` VARCHAR(256), IN `address` TEXT, IN `phoneNo` LONGTEXT, IN `uid` VARCHAR(128))  NO SQL
UPDATE users,hallauthority SET users.FirstName=firstName,users.LastName=lastName,users.fathersName=fatherName,users.mothersName=motherName,users.birthdate=birthdate,users.sex=sex,users.Email=email,users.Address=address,users.PhoneNumber=phoneNo,hallauthority.designation=designation,hallauthority.position=position,hallauthority.hallId=hid WHERE users.Id=uid AND hallauthority.userId=users.Id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `updateNewsById` (IN `newsId` INT(11), IN `title` TEXT, IN `body` LONGTEXT)  NO SQL
UPDATE news SET news.title=title, news.description=body WHERE news.id=newsId$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `updateNoticeById` (IN `noticeId` INT(11), IN `title` TEXT, IN `body` LONGTEXT)  NO SQL
UPDATE notice SET notice.title=title,notice.description=body WHERE notice.id=noticeId$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `updateStudentInfo` (IN `firstName` VARCHAR(50), IN `lastName` VARCHAR(50), IN `fatherName` VARCHAR(128), IN `motherName` VARCHAR(128), IN `sex` TEXT, IN `birthdate` DATE, IN `roll` VARCHAR(10), IN `batch` VARCHAR(10), IN `applicationNo` INT(11), IN `email` VARCHAR(256), IN `phoneNo` LONGTEXT, IN `address` TEXT, IN `uid` VARCHAR(128))  NO SQL
UPDATE users,student SET users.FirstName=firstName,users.LastName=lastName,users.fathersName=fatherName,users.mothersName=motherName,users.sex=sex,users.birthdate=birthdate,student.rollNo=roll,student.batch=batch,student.applicationId=applicationNo,users.Email=email,users.PhoneNumber=phoneNo,users.Address=address WHERE users.Id=uid AND student.userId=users.Id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `updateStudentInfo2` (IN `uid` VARCHAR(128), IN `hid` INT(11), IN `did` INT(11), IN `rid` INT(11))  NO SQL
UPDATE student SET student.hallId=hid,student.disciplineId=did,student.roomId=rid WHERE student.userId=uid$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `application`
--

CREATE TABLE `application` (
  `id` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `rollNo` varchar(10) NOT NULL,
  `lastTermCGPA` double NOT NULL,
  `disciplineId` int(11) NOT NULL,
  `fathersName` varchar(128) NOT NULL,
  `fathersOccupation` varchar(256) NOT NULL,
  `fathersYearlyIncome` varchar(15) NOT NULL,
  `mothersName` varchar(128) NOT NULL,
  `mothersOccupation` varchar(256) NOT NULL,
  `mothersYearlyIncome` varchar(15) NOT NULL,
  `batch` varchar(10) NOT NULL,
  `birthdate` date NOT NULL,
  `sex` text NOT NULL,
  `bloodGroup` text NOT NULL,
  `maritalStatus` text NOT NULL,
  `causesOfApplication` text NOT NULL,
  `hallId` int(11) NOT NULL,
  `Email` varchar(256) NOT NULL,
  `presentAddress` text,
  `permanentAddress` text NOT NULL,
  `localGuardianName` varchar(128) NOT NULL,
  `localGuardianAddress` text NOT NULL,
  `localGuardianPhoneNo` longtext NOT NULL,
  `PhoneNumber` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `application`
--

INSERT INTO `application` (`id`, `FirstName`, `LastName`, `rollNo`, `lastTermCGPA`, `disciplineId`, `fathersName`, `fathersOccupation`, `fathersYearlyIncome`, `mothersName`, `mothersOccupation`, `mothersYearlyIncome`, `batch`, `birthdate`, `sex`, `bloodGroup`, `maritalStatus`, `causesOfApplication`, `hallId`, `Email`, `presentAddress`, `permanentAddress`, `localGuardianName`, `localGuardianAddress`, `localGuardianPhoneNo`, `PhoneNumber`) VALUES
(1, 'Ashfiqur', 'Rahman', '150231', 3.5, 20, 'Father', 'Service', '1000000', 'Mother', 'Service', '1000000', '15', '1995-08-18', 'Male', 'A+', 'Unmarried', 'Security problem', 34, 'anik@anik.com', 'Khulna', 'Jhinaidah', 'Ragib Shakil', 'Khulna', '01521208398', '01521208399'),
(2, 'Ragib', 'Shakil', '151104', 3.55, 25, 'Father', 'Service', '3000000', 'Mother', 'Service', '3000000', '15', '1995-12-21', 'Male', 'A+', 'Unmarried', 'Accomodation problem', 34, 'ragib@shakil.com', 'Khulna', 'Jhinaidah', 'Anik', 'Khulna', '01521208399', '01521208398'),
(3, 'Tanmai', 'Ghosh', '150232', 3.8, 20, 'Father', 'Service', '2000000', 'Mother', 'Service', '2000000', '15', '1995-11-20', 'Male', 'O+', 'Unmarried', 'Security and Accomodation problem', 34, 'tanmai@ghosh.com', 'Khulna', 'Jhinaidah', 'Al-Amin', 'Khulna', '01677259115', '01883523059'),
(4, 'Al', 'Amin', '150212', 3.88, 20, 'Father', 'Service', '1500000', 'Mother', 'Service', '1500000', '15', '1995-07-19', 'Male', 'B+', 'Unmarried', 'Security problem', 34, 'alamin@alamin.com', 'Khulna', 'Gopalganj', 'Imran Hossain', 'Khulna', '01681717471', '01677259115'),
(5, 'Imran', 'Hossain', '150203', 3.52, 20, 'Father', 'Service', '2500000', 'Mother', 'Service', '2500000', '15', '1995-08-21', 'Male', 'B-', 'Unmarried', 'Financial problem', 34, 'imran@hossain.com', 'Khulna', 'Jessore', 'Al-Amin', 'Khulna', '01677259115', '01681717471'),
(6, 'Alamin', 'Hossain', '150316', 3.6, 21, 'Father', 'Service', '1800000', 'Mother', 'Service', '1800000', '15', '1995-06-21', 'Male', 'O+', 'Unmarried', 'Accomodation problem', 34, 'alamin@hossain.com', 'Khulna', 'Jessore', 'Antu', 'Khulna', '01521458471', '01521356927');

-- --------------------------------------------------------

--
-- Stand-in structure for view `applicationdetail`
--
CREATE TABLE `applicationdetail` (
`id` int(11)
,`FirstName` varchar(50)
,`LastName` varchar(50)
,`rollNo` varchar(10)
,`lastTermCGPA` double
,`disciplineName` varchar(128)
,`fathersName` varchar(128)
,`fathersOccupation` varchar(256)
,`fathersYearlyIncome` varchar(15)
,`mothersName` varchar(128)
,`mothersOccupation` varchar(256)
,`mothersYearlyIncome` varchar(15)
,`batch` varchar(10)
,`birthdate` date
,`sex` text
,`bloodGroup` text
,`maritalStatus` text
,`causesOfApplication` text
,`hallName` varchar(256)
,`Email` varchar(256)
,`presentAddress` text
,`permanentAddress` text
,`localGuardianName` varchar(128)
,`localGuardianAddress` text
,`localGuardianPhoneNo` longtext
,`PhoneNumber` longtext
);

-- --------------------------------------------------------

--
-- Table structure for table `discipline`
--

CREATE TABLE `discipline` (
  `id` int(11) NOT NULL,
  `hallId` int(11) NOT NULL,
  `disciplineName` varchar(128) NOT NULL,
  `allotedSeatNo` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `discipline`
--

INSERT INTO `discipline` (`id`, `hallId`, `disciplineName`, `allotedSeatNo`) VALUES
(20, 34, 'CSE', '10'),
(21, 34, 'ECE', '10'),
(22, 34, 'Math', '5'),
(24, 34, 'Physics', '5'),
(25, 34, 'Chemistry', '5');

-- --------------------------------------------------------

--
-- Table structure for table `hall`
--

CREATE TABLE `hall` (
  `id` int(11) NOT NULL,
  `hallName` varchar(256) NOT NULL,
  `totalRoomNo` varchar(10) NOT NULL,
  `totalSeatNo` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hall`
--

INSERT INTO `hall` (`id`, `hallName`, `totalRoomNo`, `totalSeatNo`) VALUES
(34, 'Khan Jahan Ali', '10', '35');

-- --------------------------------------------------------

--
-- Table structure for table `hallauthority`
--

CREATE TABLE `hallauthority` (
  `id` int(11) NOT NULL,
  `userId` varchar(128) NOT NULL,
  `hallId` int(11) NOT NULL,
  `designation` varchar(50) NOT NULL,
  `position` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hallauthority`
--

INSERT INTO `hallauthority` (`id`, `userId`, `hallId`, `designation`, `position`) VALUES
(1, '50fc0e40-03e4-40cd-bc00-7ec60d5ace1d', 34, 'Professor', 'Assistant Provost'),
(2, '88e1f46f-ca04-4d61-8cf5-ce42be2ed83e', 34, 'Lecturer', 'Superintendent');

-- --------------------------------------------------------

--
-- Stand-in structure for view `hallauthoritydetail`
--
CREATE TABLE `hallauthoritydetail` (
`HAUId` varchar(128)
,`UserName` varchar(256)
,`FirstName` varchar(50)
,`LastName` varchar(50)
,`Email` varchar(256)
,`PhoneNumber` longtext
,`sex` text
,`Address` text
,`fathersName` varchar(128)
,`mothersName` varchar(128)
,`birthdate` date
,`designation` varchar(50)
,`position` varchar(50)
,`hallName` varchar(256)
);

-- --------------------------------------------------------

--
-- Table structure for table `news`
--

CREATE TABLE `news` (
  `id` int(11) NOT NULL,
  `title` text NOT NULL,
  `description` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `news`
--

INSERT INTO `news` (`id`, `title`, `description`) VALUES
(12, 'WORLD SOIL DAY AND INTERNATIONAL YEAR OF SOIL', 'When:\r\nOctober 28, 2015 all-day\r\n2015-10-28T00:00:00-01:00\r\n2015-10-29T00:00:00-01:00\r\nCentral Events Soil Science Discipline\r\n2015 DECEMBER 05\r\nThe Soil Science Discipline of Khulna University has observed the International Year of Soil on 2015. With this we celebrate World Soil Day on 5th December every year. The theme for this year set by FAO was “Soils a solid ground for life”. It aims to connect people with soils and raise awareness on their critical importance in our lives. Soils have been neglected for too long in spite of being the basis for food, feed, fuel and fibre production and for services to ecosystems and human well-being. Soil, the reservoir for at least a quarter of global biodiversity, requires the same attention as above-ground biodiversity. Soils play a key role in the supply of clean water and resilience to floods and droughts. The largest store of terrestrial carbon is in the soil so that its preservation may contribute to climate change adaptation and mitigation. The maintenance or enhancement of global soil resources is essential if humanity’s need for food, water, and energy security is to be met.'),
(13, 'Conference on Partition', 'When:\r\nMarch 28, 2015 @ 9:30 am – March 29, 2015 @ 5:15 pm\r\n2015-03-28T09:30:00+06:00\r\n2015-03-29T17:15:00+06:00\r\nCentral Events English Discipline\r\nBangladesh is the offspring of three partitions: Banga Bhanga or the partition of Bengal in 1905, the partition of India in 1947 and the emergence of Bangladesh through a partition from Pakistan in 1971 after the war of liberation. The events surrounding these partitions traumatized generations of people. But while the first partition was annulled and the impact of the second was not long lasting, the third appears to have been the decisive one, for Bangladesh is fast approaching its fiftieth birthday. All these partitions, and the trauma and the disillusionment as well as the hope they created, have been the subject of intense reflection and debate. It was to analyze the impact the three partitions have had on our consciousness and creativity that a two-day conference on A Thrice-Partitioned Nation: Revisiting Bangladesh was organized by English Discipline on March 28-29, 2015. The program was honored by its three eminent key-note speakers of the event, Professor Syed Manzoorul Islam, Professor Fakrul Alam and Professor Hasan Azizul Haque – all three being the recipients of the Ekushey Padak. There were paper presenters from several Bangladeshi and Indian universities. Many important issues were raised by paper presenters at the conference: the effect of war and partition, the trauma of forsaking the homeland, nostalgia and memory of the land left behind, soul-searching for the causes of successive partitions, the disruption they caused in the lives of people, unexpected events such as the birth of the university of Dhaka, the fruitful ideas and ideals that led to the Liberation War of Bangladesh, its creative representations in the media and in literature and film, the visual arts, women’s narratives, etc. All these papers stimulated those present in the conference immensely and led to lively exchanges and question-answer sessions.'),
(14, 'Silver Jubilee Celebration', 'When:\r\nJanuary 25, 2016 – January 26, 2016 all-day\r\n2016-01-25T00:00:00-01:00\r\n2016-01-27T00:00:00-01:00\r\nCentral Events Fisheries & Marine Resources Technology Discipline\r\n \r\n\r\nThe FMRTians have decided at the last alumni meeting on 24th December, 2015 to celebrate its silver jubilee (25 years) on last week of January, 2016. Therefore, an ad hoc committee having nine members has been formed to start the processing soon. Hope we will make a very colourful and memorable event.'),
(15, 'Economics Discipline completed HEQEP Sub-project successfully', 'When:\r\nFebruary 28, 2013 @ 6:00 am – 7:00 am\r\n2013-02-28T06:00:00-01:00\r\n2013-02-28T07:00:00-01:00\r\nCentral Events Economics Discipline\r\nEconomics Discipline of Khulna University started its journey in 1999 through offering a four-year Bachelor of Social Science (BSS) Honors degree in Economics. Currently the Discipline is also offering a 1.5 years Master of Social Science (MSS) degree in Economics and a 16 months (4 terms) Masters of Development Studies (MDS) degree. The Discipline expresses heartfelt gratitude and conveys thanks to University Grants Commission (UGC), the World Bank and the Government of Peoples’ Republic of Bangladesh for the support provided through the Higher Education Quality Enhancement Project (HEQEP) sub-project CP-389.\r\n\r\nHEQEP sub-project helps to furnish the class-rooms of the Discipline with multimedia projector and sophisticated furniture. It boosts the book reservation of versatile branches of Economics in the seminar library. The Discipline has developed a computer laboratory having twenty computers through the sub-project. The class rooms, seminar library, computer laboratory, faculty members’ consultation room and conference room are well furnished with air condition facility through the sub-project.\r\n\r\nThe students, teachers and staffs of the Discipline have access to Internet service from any place under the territory of the Discipline by the blessings of the sub-project provided twenty-four hour free WiFi Internet facility. Such facilities encourage the stakeholders to stay longer time in the campus and utilize time more efficiently. They can instantly get access to learning facilities either in seminar library or through Internet in the computer laboratory. Accordingly, the provided facilities by HEQEP sub-project have been contributing to widen knowledge base of the students and other stakeholders of the Discipline.\r\n\r\nThe sub-project has contributed in skill development of the stakeholders of the Discipline through providing various training programs, organizing workshops, establishing agricultural and industrial linkages, arranging study tours and supporting research works & sessional courses. The provided facilities have eased direct communication and exchange of information among the stakeholders. It has accelerated students’ involvement in academic activities and brought positive changes in the teaching-learning environment of the Discipline.');

-- --------------------------------------------------------

--
-- Table structure for table `notice`
--

CREATE TABLE `notice` (
  `id` int(11) NOT NULL,
  `title` text NOT NULL,
  `description` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `notice`
--

INSERT INTO `notice` (`id`, `title`, `description`) VALUES
(5, 'e-Tender Notice No. 01/2017', '                                                         Office of the Chief Engineer\r\n                                                           Khulna University, Khulna.\r\n                                                                    www. ku.ac.bd\r\n\r\nTender No : KU,ENGG / 446/2016                                                                                  Date:09/0212017\r\n\r\n                                                        e-Tender Notice No. 01/2017\r\n\r\ne-Tender is invited in the National e-GP system portal (http/www.eprocure.gov.bd) for the procurement of\r\nThis is an online Tender, where only e-tender will be accepted in the National e-GP portal and no\r\nofflineftrard copies will be accepted.\r\nTo submit e-Tender, registration in the national e-GP system portal (http:/www.eprocure.gov.bd) is required.\r\nThe fees for downloading the e-Tender Documents from the National e-GP System Portal have to be\r\ndeposited online through any registered Bank''s branches up to Banking hours on02-Mar-2017.\r\nFurther information and guidelines are available in the National e-GP System Portal and e-GP help desk\r\n(helpdesk@eprocure.gov.bd). @,0 Md. Abdur Raz2aque\r\n\r\nChief Engineer (In-charge)\r\nKhulna University, Khulna\r\nE-mail : chiefengineer@ku.ac.bd\r\nTel:041-733729'),
(6, 'e-Tender Notice No. 01/2017', 'Tender ID\r\nNo,\r\nPackage no. Name of the works Tender Closing Date and\r\nTime\r\n86529 KU/ENGG/44612016 Construction of Boundary Wall\r\nat Khulna University, Khulna.\r\n05-Mar-2017,3:00 PM');

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `Id` varchar(128) NOT NULL,
  `Name` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`Id`, `Name`) VALUES
('4c8b4ee0-9caf-4232-a969-4f77c75dcbc4', 'Admin'),
('759225c8-c6f5-4fdd-a52d-d9d32bafc88a', 'Student'),
('f69097d3-1723-4266-8670-48c7adc9d049', 'HallAuthority');

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `id` int(11) NOT NULL,
  `hallId` int(11) NOT NULL,
  `roomNo` varchar(10) NOT NULL,
  `seatNumber` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `room`
--

INSERT INTO `room` (`id`, `hallId`, `roomNo`, `seatNumber`) VALUES
(34, 34, '101', '4'),
(35, 34, '102', '4'),
(36, 34, '103', '4'),
(37, 34, '201', '4'),
(38, 34, '202', '4'),
(40, 34, '203', '4'),
(41, 34, '301', '3'),
(42, 34, '302', '3'),
(43, 34, '401', '3'),
(44, 34, '402', '2');

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `id` int(11) NOT NULL,
  `userId` varchar(128) NOT NULL,
  `hallId` int(11) NOT NULL,
  `applicationId` int(11) NOT NULL,
  `disciplineId` int(11) NOT NULL,
  `rollNo` varchar(10) NOT NULL,
  `batch` varchar(10) NOT NULL,
  `roomId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`id`, `userId`, `hallId`, `applicationId`, `disciplineId`, `rollNo`, `batch`, `roomId`) VALUES
(1, 'b0e1198f-ca2d-4c6d-afef-3ad215d5170d', 34, 1, 20, '150231', '15', 34),
(2, '9a5ba280-7c5c-4b7b-9484-6f7f4809c18d', 34, 5, 20, '150203', '15', 41),
(3, 'cbcd67b9-c1d1-4891-914d-64c90086deb7', 34, 6, 21, '150316', '15', 36),
(4, 'ce7a5dbe-e9a8-41cb-83f4-f129f9ead1fd', 34, 2, 25, '151104', '15', 37);

-- --------------------------------------------------------

--
-- Stand-in structure for view `studentdetail`
--
CREATE TABLE `studentdetail` (
`studUId` varchar(128)
,`UserName` varchar(256)
,`FirstName` varchar(50)
,`LastName` varchar(50)
,`Email` varchar(256)
,`PhoneNumber` longtext
,`sex` text
,`Address` text
,`fathersName` varchar(128)
,`mothersName` varchar(128)
,`birthdate` date
,`applicationId` int(11)
,`rollNo` varchar(10)
,`batch` varchar(10)
,`hallName` varchar(256)
,`disciplineName` varchar(128)
,`roomNo` varchar(10)
,`bloodGroup` text
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `unacceptedapplication`
--
CREATE TABLE `unacceptedapplication` (
`id` int(11)
,`FirstName` varchar(50)
,`LastName` varchar(50)
,`rollNo` varchar(10)
,`lastTermCGPA` double
,`disciplineName` varchar(128)
,`fathersName` varchar(128)
,`fathersOccupation` varchar(256)
,`fathersYearlyIncome` varchar(15)
,`mothersName` varchar(128)
,`mothersOccupation` varchar(256)
,`mothersYearlyIncome` varchar(15)
,`batch` varchar(10)
,`birthdate` date
,`sex` text
,`bloodGroup` text
,`maritalStatus` text
,`causesOfApplication` text
,`hallName` varchar(256)
,`Email` varchar(256)
,`presentAddress` text
,`permanentAddress` text
,`localGuardianName` varchar(128)
,`localGuardianAddress` text
,`localGuardianPhoneNo` longtext
,`PhoneNumber` longtext
);

-- --------------------------------------------------------

--
-- Table structure for table `userclaims`
--

CREATE TABLE `userclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(128) NOT NULL,
  `ClaimType` longtext NOT NULL,
  `ClaimValue` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `userlogins`
--

CREATE TABLE `userlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `UserId` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `userroles`
--

CREATE TABLE `userroles` (
  `UserId` varchar(128) NOT NULL,
  `RoleId` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `userroles`
--

INSERT INTO `userroles` (`UserId`, `RoleId`) VALUES
('50fc0e40-03e4-40cd-bc00-7ec60d5ace1d', 'f69097d3-1723-4266-8670-48c7adc9d049'),
('6277ec2e-d661-421a-ae80-0fc9af682619', '4c8b4ee0-9caf-4232-a969-4f77c75dcbc4'),
('88e1f46f-ca04-4d61-8cf5-ce42be2ed83e', 'f69097d3-1723-4266-8670-48c7adc9d049'),
('9a5ba280-7c5c-4b7b-9484-6f7f4809c18d', '759225c8-c6f5-4fdd-a52d-d9d32bafc88a'),
('b0e1198f-ca2d-4c6d-afef-3ad215d5170d', '759225c8-c6f5-4fdd-a52d-d9d32bafc88a'),
('cbcd67b9-c1d1-4891-914d-64c90086deb7', '759225c8-c6f5-4fdd-a52d-d9d32bafc88a'),
('ce7a5dbe-e9a8-41cb-83f4-f129f9ead1fd', '759225c8-c6f5-4fdd-a52d-d9d32bafc88a');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `Id` varchar(128) NOT NULL,
  `UserName` varchar(256) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Email` varchar(256) NOT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext NOT NULL,
  `SecurityStamp` longtext NOT NULL,
  `PhoneNumber` longtext NOT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `sex` text NOT NULL,
  `Address` text NOT NULL,
  `fathersName` varchar(128) NOT NULL,
  `mothersName` varchar(128) NOT NULL,
  `birthdate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Id`, `UserName`, `FirstName`, `LastName`, `Email`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEndDateUtc`, `LockoutEnabled`, `AccessFailedCount`, `sex`, `Address`, `fathersName`, `mothersName`, `birthdate`) VALUES
('50fc0e40-03e4-40cd-bc00-7ec60d5ace1d', 'swajon', 'Swajon', 'Golder', 'swajon@golder.com', 0, 'AGcs3JWb6VVjs7H5OVjBB1Budif38Qgib1j0DPipTWIMqJV5EynbSKMhofi1Vx41rg==', 'b59775d5-15f4-45cd-af90-7713bef574af', '01571777609', 0, 0, '2017-03-25 04:25:17', 0, 0, 'Male', 'Khulna', 'Father', 'Mother', '1971-01-30'),
('6277ec2e-d661-421a-ae80-0fc9af682619', 'admin', 'Admin1', 'Admin2', 'admin@admin.com', 0, 'AB9U550J9v2T0UHPilIrnnwamksMSrXOFTGeIigG51MICnrnwy6cd4l+FW0BVVnZZA==', '9b7dd1d2-00d7-40b8-91da-eaba78efd5c3', '01521439394', 0, 0, '2017-03-10 03:12:30', 0, 0, 'Male', 'KJAH', 'Admin3', 'Admin4', '1995-10-30'),
('88e1f46f-ca04-4d61-8cf5-ce42be2ed83e', 'shuvo', 'Wahid', 'Shuvo', 'wahid@shuvo.com', 0, 'AJeKEu+aZKq42pE1gpCyAeUWamUyFSvwdRaCSLEm06jBMyCe9ZcZcfqtvYJCXb+WFg==', '9fc261f1-916b-47da-bac0-e0bbbea0bf85', '01933234454', 0, 0, '2017-03-25 04:27:48', 0, 0, 'Male', 'Madaripur', 'Father', 'Mother', '1973-04-24'),
('9a5ba280-7c5c-4b7b-9484-6f7f4809c18d', 'imran', 'Imran', 'Hossain', 'imran@hossain.com', 0, 'AMYp2h1/pSJo/bPE1O9Fyns4jM1BaTtAwA+lPFO5C1Acqdo4+2ajo1f33q+4KxRysg==', 'e21d87f4-f62a-46fc-9f52-abffeaa6d105', '01681717471', 0, 0, '2017-03-25 04:37:03', 0, 0, 'Male', 'Khulna', 'Father', 'Mother', '1995-08-21'),
('b0e1198f-ca2d-4c6d-afef-3ad215d5170d', 'anik', 'Ashfiqur', 'Rahman', 'anik@anik.com', 0, 'AOCRngOZu2EjxuNCSqozJEbn1SMd68YdOMOGp5YRAadmsikV9Zwy7opz+CxQiTbnfw==', 'e7ec18c5-0776-41ca-9f2e-eecc95c4c9ee', '01521208399', 0, 0, '2017-03-25 04:36:24', 0, 0, 'Male', 'Khulna', 'Father', 'Mother', '1995-08-18'),
('cbcd67b9-c1d1-4891-914d-64c90086deb7', 'alamin', 'Alamin', 'Hossain', 'alamin@hossain.com', 0, 'AMcbtP9wMT8TkklWxLySelLiGY9yy/rblaDF5Bwj2COkILXfXKeSKerXaNB+yjlYSg==', '65c9be8d-b062-449d-ada2-978e281e5d25', '01521356927', 0, 0, '2017-03-25 04:37:39', 0, 0, 'Male', 'Khulna', 'Father', 'Mother', '1995-06-21'),
('ce7a5dbe-e9a8-41cb-83f4-f129f9ead1fd', 'ragib', 'Ragib', 'Shakil', 'ragib@shakil.com', 0, 'AI1VWbugjkZQCE8T42B3PNJz67QltjdHq+5z5Htbt3QzJZDQTTskvF0FAtqUM4vWiQ==', '5a68282d-7f82-4d72-ae39-d60e25a4617b', '01521208398', 0, 0, '2017-03-25 04:38:10', 0, 0, 'Male', 'Khulna', 'Father', 'Mother', '1995-12-21');

-- --------------------------------------------------------

--
-- Structure for view `applicationdetail`
--
DROP TABLE IF EXISTS `applicationdetail`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `applicationdetail`  AS  select `application`.`id` AS `id`,`application`.`FirstName` AS `FirstName`,`application`.`LastName` AS `LastName`,`application`.`rollNo` AS `rollNo`,`application`.`lastTermCGPA` AS `lastTermCGPA`,`discipline`.`disciplineName` AS `disciplineName`,`application`.`fathersName` AS `fathersName`,`application`.`fathersOccupation` AS `fathersOccupation`,`application`.`fathersYearlyIncome` AS `fathersYearlyIncome`,`application`.`mothersName` AS `mothersName`,`application`.`mothersOccupation` AS `mothersOccupation`,`application`.`mothersYearlyIncome` AS `mothersYearlyIncome`,`application`.`batch` AS `batch`,`application`.`birthdate` AS `birthdate`,`application`.`sex` AS `sex`,`application`.`bloodGroup` AS `bloodGroup`,`application`.`maritalStatus` AS `maritalStatus`,`application`.`causesOfApplication` AS `causesOfApplication`,`hall`.`hallName` AS `hallName`,`application`.`Email` AS `Email`,`application`.`presentAddress` AS `presentAddress`,`application`.`permanentAddress` AS `permanentAddress`,`application`.`localGuardianName` AS `localGuardianName`,`application`.`localGuardianAddress` AS `localGuardianAddress`,`application`.`localGuardianPhoneNo` AS `localGuardianPhoneNo`,`application`.`PhoneNumber` AS `PhoneNumber` from ((`application` join `discipline`) join `hall`) where ((`application`.`hallId` = `hall`.`id`) and (`application`.`disciplineId` = `discipline`.`id`)) ;

-- --------------------------------------------------------

--
-- Structure for view `hallauthoritydetail`
--
DROP TABLE IF EXISTS `hallauthoritydetail`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `hallauthoritydetail`  AS  select `hallauthority`.`userId` AS `HAUId`,`users`.`UserName` AS `UserName`,`users`.`FirstName` AS `FirstName`,`users`.`LastName` AS `LastName`,`users`.`Email` AS `Email`,`users`.`PhoneNumber` AS `PhoneNumber`,`users`.`sex` AS `sex`,`users`.`Address` AS `Address`,`users`.`fathersName` AS `fathersName`,`users`.`mothersName` AS `mothersName`,`users`.`birthdate` AS `birthdate`,`hallauthority`.`designation` AS `designation`,`hallauthority`.`position` AS `position`,`hall`.`hallName` AS `hallName` from ((`users` join `hallauthority`) join `hall`) where ((`hallauthority`.`userId` = `users`.`Id`) and (`hallauthority`.`hallId` = `hall`.`id`)) ;

-- --------------------------------------------------------

--
-- Structure for view `studentdetail`
--
DROP TABLE IF EXISTS `studentdetail`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `studentdetail`  AS  select `student`.`userId` AS `studUId`,`users`.`UserName` AS `UserName`,`users`.`FirstName` AS `FirstName`,`users`.`LastName` AS `LastName`,`users`.`Email` AS `Email`,`users`.`PhoneNumber` AS `PhoneNumber`,`users`.`sex` AS `sex`,`users`.`Address` AS `Address`,`users`.`fathersName` AS `fathersName`,`users`.`mothersName` AS `mothersName`,`users`.`birthdate` AS `birthdate`,`student`.`applicationId` AS `applicationId`,`student`.`rollNo` AS `rollNo`,`student`.`batch` AS `batch`,`hall`.`hallName` AS `hallName`,`discipline`.`disciplineName` AS `disciplineName`,`room`.`roomNo` AS `roomNo`,`application`.`bloodGroup` AS `bloodGroup` from (((((`users` join `student`) join `hall`) join `discipline`) join `room`) join `application`) where ((`student`.`userId` = `users`.`Id`) and (`student`.`disciplineId` = `discipline`.`id`) and (`student`.`hallId` = `hall`.`id`) and (`student`.`roomId` = `room`.`id`) and (`student`.`applicationId` = `application`.`id`)) ;

-- --------------------------------------------------------

--
-- Structure for view `unacceptedapplication`
--
DROP TABLE IF EXISTS `unacceptedapplication`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `unacceptedapplication`  AS  select `applicationdetail`.`id` AS `id`,`applicationdetail`.`FirstName` AS `FirstName`,`applicationdetail`.`LastName` AS `LastName`,`applicationdetail`.`rollNo` AS `rollNo`,`applicationdetail`.`lastTermCGPA` AS `lastTermCGPA`,`applicationdetail`.`disciplineName` AS `disciplineName`,`applicationdetail`.`fathersName` AS `fathersName`,`applicationdetail`.`fathersOccupation` AS `fathersOccupation`,`applicationdetail`.`fathersYearlyIncome` AS `fathersYearlyIncome`,`applicationdetail`.`mothersName` AS `mothersName`,`applicationdetail`.`mothersOccupation` AS `mothersOccupation`,`applicationdetail`.`mothersYearlyIncome` AS `mothersYearlyIncome`,`applicationdetail`.`batch` AS `batch`,`applicationdetail`.`birthdate` AS `birthdate`,`applicationdetail`.`sex` AS `sex`,`applicationdetail`.`bloodGroup` AS `bloodGroup`,`applicationdetail`.`maritalStatus` AS `maritalStatus`,`applicationdetail`.`causesOfApplication` AS `causesOfApplication`,`applicationdetail`.`hallName` AS `hallName`,`applicationdetail`.`Email` AS `Email`,`applicationdetail`.`presentAddress` AS `presentAddress`,`applicationdetail`.`permanentAddress` AS `permanentAddress`,`applicationdetail`.`localGuardianName` AS `localGuardianName`,`applicationdetail`.`localGuardianAddress` AS `localGuardianAddress`,`applicationdetail`.`localGuardianPhoneNo` AS `localGuardianPhoneNo`,`applicationdetail`.`PhoneNumber` AS `PhoneNumber` from `applicationdetail` where (not(`applicationdetail`.`id` in (select `student`.`applicationId` from `student`))) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `application`
--
ALTER TABLE `application`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `rollNo` (`rollNo`),
  ADD KEY `disciplineId` (`disciplineId`),
  ADD KEY `hallId` (`hallId`);

--
-- Indexes for table `discipline`
--
ALTER TABLE `discipline`
  ADD PRIMARY KEY (`id`),
  ADD KEY `hallId` (`hallId`);

--
-- Indexes for table `hall`
--
ALTER TABLE `hall`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `hallauthority`
--
ALTER TABLE `hallauthority`
  ADD PRIMARY KEY (`id`),
  ADD KEY `userId` (`userId`),
  ADD KEY `hallId` (`hallId`);

--
-- Indexes for table `news`
--
ALTER TABLE `news`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `notice`
--
ALTER TABLE `notice`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`id`),
  ADD KEY `hallId` (`hallId`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `rollNo` (`rollNo`),
  ADD KEY `userId` (`userId`),
  ADD KEY `hallId` (`hallId`),
  ADD KEY `applicationId` (`applicationId`),
  ADD KEY `disciplineId` (`disciplineId`),
  ADD KEY `roomId` (`roomId`);

--
-- Indexes for table `userclaims`
--
ALTER TABLE `userclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `UserId` (`UserId`);

--
-- Indexes for table `userlogins`
--
ALTER TABLE `userlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`,`UserId`),
  ADD KEY `UserId` (`UserId`);

--
-- Indexes for table `userroles`
--
ALTER TABLE `userroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `UserId` (`UserId`),
  ADD KEY `RoleId` (`RoleId`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Email` (`Email`),
  ADD UNIQUE KEY `UserName` (`UserName`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `application`
--
ALTER TABLE `application`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `discipline`
--
ALTER TABLE `discipline`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
--
-- AUTO_INCREMENT for table `hall`
--
ALTER TABLE `hall`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;
--
-- AUTO_INCREMENT for table `hallauthority`
--
ALTER TABLE `hallauthority`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `news`
--
ALTER TABLE `news`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT for table `notice`
--
ALTER TABLE `notice`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `room`
--
ALTER TABLE `room`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;
--
-- AUTO_INCREMENT for table `student`
--
ALTER TABLE `student`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `userclaims`
--
ALTER TABLE `userclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `application`
--
ALTER TABLE `application`
  ADD CONSTRAINT `application_ibfk_1` FOREIGN KEY (`disciplineId`) REFERENCES `discipline` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `application_ibfk_2` FOREIGN KEY (`hallId`) REFERENCES `hall` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `discipline`
--
ALTER TABLE `discipline`
  ADD CONSTRAINT `discipline_ibfk_1` FOREIGN KEY (`hallId`) REFERENCES `hall` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `hallauthority`
--
ALTER TABLE `hallauthority`
  ADD CONSTRAINT `hallauthority_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `hallauthority_ibfk_2` FOREIGN KEY (`hallId`) REFERENCES `hall` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `room`
--
ALTER TABLE `room`
  ADD CONSTRAINT `room_ibfk_1` FOREIGN KEY (`hallId`) REFERENCES `hall` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `student`
--
ALTER TABLE `student`
  ADD CONSTRAINT `student_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `student_ibfk_2` FOREIGN KEY (`hallId`) REFERENCES `hall` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `student_ibfk_3` FOREIGN KEY (`disciplineId`) REFERENCES `discipline` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `student_ibfk_4` FOREIGN KEY (`applicationId`) REFERENCES `application` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `student_ibfk_5` FOREIGN KEY (`roomId`) REFERENCES `room` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `userclaims`
--
ALTER TABLE `userclaims`
  ADD CONSTRAINT `userclaims_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `userlogins`
--
ALTER TABLE `userlogins`
  ADD CONSTRAINT `userlogins_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `userroles`
--
ALTER TABLE `userroles`
  ADD CONSTRAINT `userroles_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `userroles_ibfk_2` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
