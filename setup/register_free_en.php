<?php

$email=$_POST['freeactivate-email'];
#$serial=$_POST['serial'];
#$ip=$_POST['ip'];

$config['smtp_username'] = 'info@asteriskphoneagent.com'; 
$config['smtp_port']     = 2525; 
$config['smtp_host']     = 'smtp.spaceweb.ru'; 
$config['smtp_password'] = '485rgbTHY'; 
$config['smtp_debug']    = true;  
$config['smtp_charset']  = 'UTF-8'; 
$config['smtp_from']     = 'New message'; 
$ip=$_SERVER['REMOTE_ADDR']; 



ob_start();

function response($responseStatus, $responseMsg) {
  $out = json_encode(array('responseStatus' => $responseStatus, 'responseMsg' => $responseMsg));
  ob_end_clean();
  error_log($out,0);
  print $out;
  die();
}

// only AJAX calls allowed
if (!isset($_SERVER['X-Requested-With']) && !isset($_SERVER['HTTP_X_REQUESTED_WITH'])) {
  response('err', 'ajax');
  error_log('ajax',0);
}

function smtpmail($mail_to, $subject, $message, $headers='') {
    global $config;
    $SEND =    "Date: ".date("D, d M Y H:i:s") . " \r\n";
    $SEND .=    'Subject: =?'.$config['smtp_charset'].'?B?'.base64_encode($subject)."=?=\r\n";
    if ($headers) $SEND .= $headers."\r\n\r\n";
    else
    {
            $SEND .= "Reply-To: ".$config['smtp_username']."\r\n";
            $SEND .= "MIME-Version: 1.0\r\n";
            $SEND .= "Content-Type: text/plain; charset=\"".$config['smtp_charset']."\"\r\n";
            $SEND .= "Content-Transfer-Encoding: 8bit\r\n";
            $SEND .= "From: \"".$config['smtp_from']."\" <".$config['smtp_username'].">\r\n";
            $SEND .= "To: $mail_to <$mail_to>\r\n";
            $SEND .= "X-Priority: 3\r\n\r\n";
    }
    $SEND .=  $message."\r\n";
     if( !$socket = fsockopen($config['smtp_host'], $config['smtp_port'], $errno, $errstr, 30) ) {
        if ($config['smtp_debug']) echo $errno."<br>".$errstr;
        return false;
     }
 
    if (!server_parse($socket, "220", __LINE__)) return false;
 
    fputs($socket, "HELO " . $config['smtp_host'] . "\r\n");
    if (!server_parse($socket, "250", __LINE__)) {
        fclose($socket);
        return false;
    }
    fputs($socket, "AUTH LOGIN\r\n");
    if (!server_parse($socket, "334", __LINE__)) {
        fclose($socket);
        return false;
    }
    fputs($socket, base64_encode($config['smtp_username']) . "\r\n");
    if (!server_parse($socket, "334", __LINE__)) {
        fclose($socket);
        return false;
    }
    fputs($socket, base64_encode($config['smtp_password']) . "\r\n");
    if (!server_parse($socket, "235", __LINE__)) {
        fclose($socket);
        return false;
    }
    fputs($socket, "MAIL FROM: <".$config['smtp_username'].">\r\n");
    if (!server_parse($socket, "250", __LINE__)) {
        fclose($socket);
        return false;
    }
    fputs($socket, "RCPT TO: <" . $mail_to . ">\r\n");
 
    if (!server_parse($socket, "250", __LINE__)) {
        fclose($socket);
        return false;
    }
    fputs($socket, "DATA\r\n");
 
    if (!server_parse($socket, "354", __LINE__)) {
        fclose($socket);
        return false;
    }
    fputs($socket, $SEND."\r\n.\r\n");
 
    if (!server_parse($socket, "250", __LINE__)) {
        fclose($socket);
        return false;
    }
    fputs($socket, "QUIT\r\n");
    fclose($socket);
    return TRUE;
}
 
function server_parse($socket, $response, $line = __LINE__) {
    global $config;
    while (@substr($server_response, 3, 1) != ' ') {
        if (!($server_response = fgets($socket, 256))) {
            if ($config['smtp_debug']) response('err', 'mail');
             return false;
         }
    }
    if (!(substr($server_response, 0, 3) == $response)) {
        if ($config['smtp_debug']) response('err', 'mail');
        return false;
    }
    return true;
}
							


$con = mysql_connect("localhost","root","QXflsI14!");
if (!$con)
  {
  die('Could not connect: ' . mysql_error());
  }

mysql_select_db("apa", $con);

$result = mysql_query("insert into serial_log (customer_id, from_ip, log_text) values (0,'".$ip."','try to activate |email:".$email."'") ;

$result = mysql_query("select customer_id from customer where email='".$email."'");
if (mysql_num_rows($result) > 0)
{
  while($row = mysql_fetch_array($result))
    {
        response('err', 'already');
    }

} else { 

    $result1 = mysql_query("insert into serial_log (from_ip, log_text) values ('".$ip."','act_free email ".$email."')") ;
    $result1 = mysql_query("insert into customer (email, status, date_added) values ('".$email."',1, now())") ;
    $result2 = mysql_query("select customer_id from customer where email='".$email."'");
    $id="";
    if ($result2)
	{        	
	  $row1 = mysql_fetch_array($result2);
  	  $id = $row1['customer_id'];
        }
    $collection = "";
    for($i = 1; $i <= 5; $i++){
	$s = strtoupper(substr(sha1(microtime() . $i), rand(0, 5), 5));
	$collection.=$s;
	if (($i>0)&&($i<5))
	{
		$collection.="-";
	}
    }
    
    $result3 = mysql_query("insert into serial (customer_id, license_type, license_count_current, license_count_first, passkey, comment, date_added)  
				values (".$id.",1,2,2,'".$collection."','free', now())") ;
    
    mysql_close($con);

    $headers  = 'MIME-Version: 1.0' . "\r\n";
    $headers .= 'Content-type: text/html; charset="windows-1251"' . "\r\n";
    $headers .= 'From: "AsteriskPhoneAgent Site Message" <info@asteriskphoneagent.com>'. "\r\n";

    smtpmail("anton.zheltov@gmail.com", "Free APA activation", "From "." email ".$email." key ".$collection, $headers);

    smtpmail($email, "AsteriskPhoneAgent key", "Your APA free activation key for 2 users is ".$collection, $headers);

    response('ok', 'checkemail');

}

// some code
?> 
