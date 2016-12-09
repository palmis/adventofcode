open System

printfn "Advent of code 2016. Day 33 problem 1"
printfn "http://adventofcode.com/2016/day/3"

let input = System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__+ @"\day3_part1_input.txt");
let input_example_1 = [|"   50   94    8"; "  490  544  485"; "  234  609  877"|] // 1

let parse (input : string) = 
  input.Split([|' '|], StringSplitOptions.RemoveEmptyEntries)
  |> Array.map System.Int32.Parse

  // split by " "
  // get list of f

let is_triangle [|a, b, c|] =
  printfn "%d %d %d" a b c

is_triangle [|1, 2, 3|]
//   procedure
//   |> Seq.toList
//   |> List.fold bathroom_procedure button

input_example_1
|> Array.map parse
|> Array.map is_triangle
//|> Array.tail
// Seq.where 

// http://stackoverflow.com/questions/20825237/converting-a-list-of-strings-into-floats-ints-in-f
// https://www.dotnetperls.com/convert-fs