 Сервер: localhost  -   База данных: asteriskcdrdb
 
-- phpMyAdmin SQL Dump
-- version 2.11.11
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Время создания: Фев 17 2016 г., 10:25
-- Версия сервера: 5.0.95
-- Версия PHP: 5.1.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

--
-- База данных: `asteriskcdrdb`
--

-- --------------------------------------------------------

--
-- Структура таблицы `callers`
--

CREATE TABLE IF NOT EXISTS `callers` (
  `callerid` int(11) NOT NULL auto_increment,
  `fio` varchar(100) NOT NULL,
  `organization` varchar(100) default NULL,
  `department` varchar(100) default NULL,
  `position` varchar(100) default NULL,
  `mainphone` varchar(20) NOT NULL,
  `cellphone` varchar(20) default NULL,
  `workphone` varchar(20) default NULL,
  `email` varchar(50) default NULL,
  `note` longtext,
  `important` tinyint(4) default '0',
  `personal` varchar(20) NOT NULL,
  `callercreator` varchar(20) NOT NULL,
  `datecreate` datetime default NULL,
  `deleted` tinyint(4) default '0',
  PRIMARY KEY  (`callerid`),
  KEY `fio` (`fio`,`mainphone`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=1001 ;

--
-- Дамп данных таблицы `callers`
--

INSERT INTO `callers` (`callerid`, `fio`, `organization`, `department`, `position`, `mainphone`, `cellphone`, `workphone`, `email`, `note`, `important`, `personal`, `callercreator`, `datecreate`, `deleted`) VALUES
(1, 'Kayden Acosta', 'Brand Inc.', 'Sales', 'Manager', '5554443331', '3554243221', NULL, 'sales@brand.com', '', 0, 'ALL', 'zheltov.aa', '2016-01-22 09:09:52', 0),
(2, 'Hayden Oconnell', 'Brand Inc.', 'Sales', 'Manager', '5554443331', '3554243221', NULL, 'sales@brand.com', '', 0, 'ALL', 'zheltov.aa', '2016-01-22 09:09:52', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `callerschange`
--

CREATE TABLE IF NOT EXISTS `callerschange` (
  `chdatetime` datetime default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `callerschange`
--

