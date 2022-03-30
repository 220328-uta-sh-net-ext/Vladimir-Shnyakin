#!/usr/bin/bash

#created function to loop the whole program if user wants to go again
function FizzBuzz {
#loop will be running until user puts in correct number except some errors I didn't catch
while true
do
#letting user know what to put
    read -p 'Please enter a number between 1 and 20: ' number
    if [[ $number -le 20 && $number -ge 1 ]]
    then
        break
    else
    #letting user know his number is outside the scope
        echo 'I dont like your number. Please try again!'
    fi
done
#if the imputted number is correct lets check if it can be divided by 3 or 5 without remainder
if [ $number -le 20 ]
then
#can it be divided both by 3 and by 5?
    if [[ $((number%3)) -eq 0 && $((number%5)) -eq 0 ]]
    #if yes print fizzbuzz
    then echo fizzbuzz
    else
        if [ $((number%5)) -eq 0 ]
        then echo buzz
        elif [ $((number%3)) -eq 0 ]
        then echo fizz
        else
        #if it can't be divided by neither by 3 nor by 5 let them know
            echo 'Your number is indivisible by 3 or 5'
        #don't forget to 'close' ALL ifs
        fi
    fi
fi
}
#function FizzBuzz ends here
#have to initialize variable named 'quit'. It can qual anything
quit=n
#until quit becomes equal 'q'....
while [[ "$quit" != q ]]
do 
#we will continue calling FizzBuzz function. This is how the program can repeat itself
    FizzBuzz
    read -p "Press 'Enter' to try again or 'q' to quit: " quit  
done