open System

printfn "Advent of code 2015. Day 2, problem 2"
printfn "http://adventofcode.com/2015/day/2"

let input = System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__+ @"\day2_part2_input.txt");

let split_to_array_by (splitter : char) (str : string) =
  str.Split( [|splitter|], StringSplitOptions.RemoveEmptyEntries )

let feet_of_ribbon ([| length; width; height |] as present) =
  let [| minA; minB |] = (Array.sort present ).[0..1]
  (minA + minA + minB + minB) + (length * width * height)

input
|> Array.map ( split_to_array_by 'x' )
|> Array.map (fun arr -> arr |> Array.map System.Int32.Parse)
|> Array.map ( feet_of_ribbon )
|> Array.sum
