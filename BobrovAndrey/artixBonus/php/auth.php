<?php
require_once "connect.php";
if(!isset($_POST['login']) || !isset($_POST['pass'])) {
    header('Location: ../');
    exit;
}
$recaptcha = $_POST['g-recaptcha-response'];
if(1) {

    //Получаем HTTP от recaptcha
    $recaptcha = $_REQUEST['g-recaptcha-response'];
    //Сюда пишем СЕКРЕТНЫЙ КЛЮЧ, который нам присвоил гугл
    $secret = '6LdiJqoZAAAAAJ6DEPjQlckNSzqhKBMrcnbA63ef';
    //Формируем utl адрес для запроса на сервер гугла
    $url = "https://www.google.com/recaptcha/api/siteverify?secret=".$secret ."&response=".$recaptcha."&remoteip=".$_SERVER['REMOTE_ADDR'];

    //Инициализация и настройка запроса
    $curl = curl_init();
    curl_setopt($curl, CURLOPT_URL, $url);
    curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
    curl_setopt($curl, CURLOPT_TIMEOUT, 10);
    curl_setopt($curl, CURLOPT_USERAGENT, "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.16) Gecko/20110319 Firefox/3.6.16");
    //Выполняем запрос и получается ответ от сервера гугл
    $curlData = curl_exec($curl);

    curl_close($curl);
    //Ответ приходит в виде json строки, декодируем ее
    $curlData = json_decode($curlData, true);

    //Смотрим на результат
    if(1) {
        $login = $_POST['login'];
        $login = mysqli_real_escape_string($link, $login);
        $pass = $_POST['pass'];
        $pass = mysqli_real_escape_string($link, $pass);
        $result = mysqli_query($link, "(SELECT password, privilege_id FROM users WHERE login='$login')");
        $hash = mysqli_fetch_array($result);
        if(password_verify($pass, $hash[0])){
            $result2 = mysqli_query($link, "(SELECT title FROM privilegies WHERE id='$hash[1]')");
            $status = mysqli_fetch_array($result2);

            session_start();
            $_SESSION['login'] = $login;
            $_SESSION['status'] = $status[0];
            header('Location: ../profile.php');
            exit;
        }
        else{
            session_start();
            $_SESSION['message'] = "Аккаунт с таким логином не существует, либо введен неверный пароль!";
            header('Location: ../');
            exit;
        }

    } else {
        session_start();
        $_SESSION['message'] = "Каптча не пройдена!";
        header('Location: ../');
        exit;
    }
}
else {
    session_start();
    $_SESSION['message'] = "Каптча не пройдена!";
    header('Location: ../');
    exit;
}
?>