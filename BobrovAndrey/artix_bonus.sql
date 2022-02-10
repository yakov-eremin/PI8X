-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Фев 10 2022 г., 10:31
-- Версия сервера: 10.3.13-MariaDB-log
-- Версия PHP: 7.1.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `artix_bonus`
--

-- --------------------------------------------------------

--
-- Структура таблицы `privilegies`
--

CREATE TABLE `privilegies` (
  `id` int(11) NOT NULL,
  `title` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `privilegies`
--

INSERT INTO `privilegies` (`id`, `title`) VALUES
(1, 'user'),
(2, 'admin');

-- --------------------------------------------------------

--
-- Структура таблицы `transactions`
--

CREATE TABLE `transactions` (
  `id` int(11) NOT NULL,
  `title` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `about` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `price` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `transactions`
--

INSERT INTO `transactions` (`id`, `title`, `about`, `price`) VALUES
(2, 'Я.музыка', 'Покупка подписки на Яндекс музыку', 322),
(4, 'Грильница', 'Скидка на шаурму', 45),
(5, 'Я.такси', 'Скидка на проезд', 50),
(6, 'KFC', 'Скидка на заказ', 100),
(7, 'Школа SkyEng', 'Скидка на занятие', 250),
(8, 'Аэрофлот', 'Скидка на полет', 2000),
(9, 'Hostinger', 'Скидка на хостинг', 50);

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `login` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `firstname` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `lastname` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `address` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `email` varchar(30) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `points` int(11) NOT NULL,
  `privilege_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id`, `login`, `password`, `firstname`, `lastname`, `address`, `email`, `points`, `privilege_id`) VALUES
(6, 'user', '$2y$10$CrggzDhHss5qkgg4Y90ahurAOwDl9G3aksVE7xwExpK.AqlNcRpAG', 'Ондрей', 'Бобров', 'г. Барнаул ул. Попова 42 кв. 6', 'upndrey@yandex.ru', 2378, 2),
(7, 'user2', '$2y$10$CrggzDhHss5qkgg4Y90ahurAOwDl9G3aksVE7xwExpK.AqlNcRpAG', 'Андрей', 'Бобров', 'г. Барнаул ул. Попова 42 кв. 6', 'upndrey@yandex.ru', 250, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `user_transactions`
--

CREATE TABLE `user_transactions` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `transaction_id` int(11) NOT NULL,
  `date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `user_transactions`
--

INSERT INTO `user_transactions` (`id`, `user_id`, `transaction_id`, `date`) VALUES
(6, 6, 2, '2020-07-09 02:07:33'),
(8, 7, 5, '2020-07-09 03:07:35'),
(9, 7, 5, '2020-07-09 03:07:43'),
(10, 7, 8, '2020-07-09 03:07:50'),
(11, 7, 8, '2020-07-09 03:07:11'),
(12, 7, 7, '2020-07-09 03:07:50'),
(13, 7, 5, '2020-07-09 03:07:37'),
(14, 7, 5, '2020-07-09 03:07:32'),
(15, 7, 6, '2020-07-09 03:07:05'),
(16, 7, 6, '2020-07-09 10:07:24'),
(17, 7, 6, '2020-07-10 06:07:18'),
(18, 6, 5, '2020-07-15 11:07:09'),
(19, 6, 7, '2020-07-15 11:07:13'),
(20, 6, 8, '2020-07-15 11:07:16'),
(21, 6, 2, '2020-07-15 11:07:20');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `privilegies`
--
ALTER TABLE `privilegies`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `user_transactions`
--
ALTER TABLE `user_transactions`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `privilegies`
--
ALTER TABLE `privilegies`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `transactions`
--
ALTER TABLE `transactions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `user_transactions`
--
ALTER TABLE `user_transactions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
