<?php

$email=$_GET['email'];
$serial=$_GET['serial'];

$con = mysql_connect("localhost","root","123");
if (!$con)
  {
  die('Could not connect: ' . mysql_error());
  }

mysql_select_db("shop", $con);

$result = mysql_query("insert into customer_astcrm_log (customer_id, from_ip, log_text) values (0,'','try to activate passkey:".$passkey."|email:".$email."|actkey:".$actkey."')") ;

$result = mysql_query("SELECT * FROM customer_astcrm WHERE customer_id=(select customer_id from customer where email='".$email."')");
if (mysql_num_rows($result) > 0)
{
  while($row = mysql_fetch_array($result))
    {
      $customer_astcrm_id=$row['customer_id'];
      $passkeydb=$row['passkey'];
      $license_count_current=$row['license_count_current'];
      $license_count_first=$row['license_count_first'];
    }
} else { print "Email not found"; }

if ($passkey!=$passkeydb || $license_count_current==0)
{
   if ($passkey!=$passkeydb )die("Error! <br>Email: ".$email." <br>Wrong passkey: " . $passkey);
   if ($license_count_current==0 )die("Error! <br>Email: ".$email." <br>License count 0. Visit <a href='http://xtelekom.ru'>xtelekom.ru</a> to buy more" );
}  else
{
    print "User ".$email."<br> Total license count ".$license_count_first."<br> Current license count ".$license_count_current;
    print "<p> Activating... </p>";
    $lic=$license_count_current-1;
    $result = mysql_query("update customer_astcrm set license_count_current=".$lic." WHERE customer_id=".$customer_astcrm_id);
    $result = mysql_query("insert into customer_astcrm_log (customer_id, from_ip, log_text) values (".$customer_astcrm_id.",'','act_lic ".$license_count_current."/".$license_count_first."')") ;
    print "<p> Activate key: [key]".md5($actkey."DfTgnh432!!5g@#±hjklt".$email)."[/key] </p>";

}

mysql_close($con);
// some code
?> 
