<?php
	$src = new DOMDocument('1.0', 'utf-8');
	$src->formatOutput = true;
	$src->preserveWhiteSpace = false;
	$content = file_get_contents("https://trendogate.com/search/?trend=draintheswamp");
	@$src->loadHTML($content);
	$xpath = new DOMXPath($src);
	$values=$xpath->query('//td');

	$tweets = array();
	$dates = array();
	$i = -1;
	foreach($values as $value) {
		if($i % 5 == 0) {
			//Tue, 18 Oct 2016 23:50:14
			$tweets[$i] = new DateTime($value->nodeValue);
			if($tweets[$i] != null) {
				if(array_key_exists($tweets[$i]->format('Y-M-D'), $dates))
					$dates[$tweets[$i]->format('Y-M-D')]++;
				else
					$dates[$tweets[$i]->format('Y-M-D')] = 1;

			}
			echo $value->nodeValue . "\r\n";
		}
		$i++;
	}

	print_r($dates);


?>