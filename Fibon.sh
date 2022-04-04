#!/usr/bin/bash
read N

a=0
  
b=1 
   
for (( i=0; i<N; i++ ))
do
    fn=$((a + b))
    a=$b
    b=$fn
done
echo $a

while [ $fn -gt 0 ]
do
    mod=$(( $fn % 10))
    sum=$((sum + mod))
    fn=$((num / 10))
done