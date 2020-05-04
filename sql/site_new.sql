
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- База данных: `shop`
--

-- --------------------------------------------------------

--
-- Структура таблицы `serial`
--
drop table `serial`;
CREATE TABLE IF NOT EXISTS `serial` (
  `serial_id` int(11) NOT NULL,
  `customer_id` VARCHAR(100) NOT NULL,
  `license_type` int(11) NOT NULL DEFAULT '1',
  `license_count_first` int(11) NOT NULL DEFAULT '1',
  `license_count_current` int(11) NOT NULL DEFAULT '0',
  `passkey` varchar(15) NOT NULL,
  `comment` text,
  `date_added` datetime 
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

ALTER TABLE `serial`
  ADD KEY `serial_id` (`serial_id`);
--
-- Дамп данных таблицы `serial`
--

INSERT INTO `serial` (`serial_id`, `customer_id`, `license_type`, `license_count_first`, `license_count_current`, `passkey`, `comment`, `date_added`) VALUES
(1, 2, 1, 100, 74, '12QWEasd123', NULL, NOW());

-- --------------------------------------------------------

--
-- Структура таблицы `serial_log`
--

CREATE TABLE IF NOT EXISTS `serial_log` (
  `serial_log_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `from_ip` varchar(15) NOT NULL DEFAULT '1',
  `log_text` text,
  `date_added` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `serial_log`
--

INSERT INTO `serial_log` (`serial_log_id`, `customer_id`, `from_ip`, `log_text`, `date_added`) VALUES
(1, 5, '0', 'act_lic 4/10', '2013-02-24 16:15:57'),
(2, 0, '78.132.137.174', 'update search', '2016-01-13 07:49:20');

-- --------------------------------------------------------

--
-- Структура таблицы `serial_update`
--

CREATE TABLE IF NOT EXISTS `serial_update` (
  `current_ver` varchar(15) NOT NULL,
  `link` varchar(255) DEFAULT NULL,
  `date_added` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `serial_update`
--

INSERT INTO `serial_update` (`current_ver`, `link`, `date_added`) VALUES
('2.1.11', 'https://asteriskphoneagent.com/download/AsteriskPhoneAgent_2.1.11_setup.exe', '2016-01-10 06:21:59');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `serial`
--
ALTER TABLE `serial`
  ADD PRIMARY KEY (`serial_id`);

--
-- Индексы таблицы `serial_log`
--
ALTER TABLE `serial_log`
  ADD PRIMARY KEY (`serial_log_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `serial`
--
ALTER TABLE `serial`
  MODIFY `serial_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `serial_log`
--
ALTER TABLE `serial_log`
  MODIFY `serial_log_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;