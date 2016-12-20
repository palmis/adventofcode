open System

printfn "Advent of code 2016. Day 33 problem 1"
printfn "http://adventofcode.com/2016/day/3"

let input = System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__+ @"\day3_part1_input.txt");
let input_example_1 = [|"   50   94    8"; "  490  544  485"; "  234  609  877"|] // 1

let parse (input : string) = 
  input.Split([|' '|], StringSplitOptions.RemoveEmptyEntries)
  |> Array.map System.Int32.Parse

let is_triangle [|a; b; c|] =
  if( (a+b) > c && (a+c) > b && (b+c) > a ) then 1
  else 0

input
|> Array.map parse
|> Array.map is_triangle 
|> Array.sum
