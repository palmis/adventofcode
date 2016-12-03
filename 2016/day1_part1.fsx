open System

printfn "Advent of code 2016. Day 1 problem 1"
printfn "http://adventofcode.com/2016/day/1"

// Distance between two points (p1, q1) and (p2, q2 ) in a plane is;
// |p1 - p2| + |q1 - q2| 

let input = System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__+ @"\day1_part1_input.txt");
let input_example_1 = [|"R2, L3"|] // 5 : (0,0) (2,3) = |0-2| + |0-3| = 5
let input_example_2 = [|"R2, R2, R2"|] // 2 : (0,0) (0,-2) = |0-0| + |0-2| = 2
let input_example_3 = [|"R5, L5, R5, R3"|] // 12 : (0,0) -> (5,0) -> (5,5) -> (10,5) -> (7,5) = |0-7| + |0-5| = 12

type Direction = North | South | East | West

let move (current_direction : Direction, x : int, y : int) (code : string) =
  let next_direction = code.Substring(0, 1);
  let steps = System.Int32.Parse( code.Substring(1, code.Length - 1) )
  match (current_direction, next_direction) with
  | (North, "R") -> (East, x+steps, y)
  | (North, "L") -> (West, x-steps, y)
  | (South, "R") -> (West, x-steps, y)
  | (South, "L") -> (East, x+steps, y)
  | (East, "R") -> (South, x, y-steps)
  | (East, "L") -> (North, x, y+steps)
  | (West, "R") -> (North, x, y+steps)
  | (West, "L") -> (South, x, y-steps)

input.[0]
|> (fun (x) -> x.Replace(" ", "").Split([|','|], StringSplitOptions.RemoveEmptyEntries))
|> Array.scan move (North, 0, 0)
|> (fun directions -> 
  let _, p1, q1 = directions.[0]
  let _, p2, q2 = directions.[directions.Length-1]
  abs(p1 - p2) + abs(q1 - q2) )
