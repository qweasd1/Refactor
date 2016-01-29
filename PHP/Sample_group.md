function array_category($data, $levels){
   $root = array();
   foreach($data as $row){       
       $cursor = &$root;
       foreach($levels as $lev){
          $category = $row[$lev];
          
          if(!key_exists($category, $cursor)) {
             
             $cursor[$category] = array();
             //$cursor[$category]['_count'] = 0;
          }
          //$cursor[$category]['_count']++;
          $cursor = &$cursor[$category];
          
       }       
   }
   
   return $root;
}

$data = array(
   array( 'l1'=>'A', 'l2'=>'A1', 'value'=> 'item1'),
   array( 'l1'=>'A', 'l2'=>'A2', 'value'=> 'item2'),
   array( 'l1'=>'A', 'l2'=>'A2', 'value'=> 'item2')
);

//reduce practice
$tt = array_reduce($data, function($pre,$next){    
   $tag = $next['value'];
   if(!key_exists($tag, $pre)){
      $pre[$tag] = 0;
   }
   $pre[$tag]++; 
   return $pre;
},array());

arsort($tt, SORT_DESC);
//print_r($tt);

print_r(array_category($data, array('l1','l2','value')));
