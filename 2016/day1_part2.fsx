open System

printfn "Advent of code 2016. Day 1 problem 2"
printfn "http://adventofcode.com/2016/day/1"

// Distance between two points (p1, q1) and (p2, q2 ) in a plane is;
// |p1 - p2| + |q1 - q2| 

let input = System.IO.File.ReadAllText(__SOURCE_DIRECTORY__+ @"\day1_part1_input.txt");
let input_example_1 = "R8, R4, R4, R8" // 4 : (0,0)->(8,0)->(8,-4)->(4,-4)->(4,4) = (0,0) (4,0) = 4

type Direction = North | South | East | West

let list_of n (direction : Direction) =
  [for i in 1..n do yield direction]

let explicit_directions (directions : Direction list) (code : string) =
  let next_direction = code.Substring(0, 1);
  let steps = System.Int32.Parse( code.Substring(1, code.Length - 1) )
  let current_direction = match directions.Length with
    | 0 -> North
    | _ -> directions |> List.rev |> List.head
  let expanded_steps = match (current_direction, next_direction) with
    | (North, "R") -> list_of steps East
    | (North, "L") -> list_of steps West
    | (South, "R") -> list_of steps West
    | (South, "L") -> list_of steps East
    | (East, "R") -> list_of steps South
    | (East, "L") -> list_of steps North
    | (West, "R") -> list_of steps North
    | (West, "L") -> list_of steps South
  directions @ expanded_steps
  
let move_in_plane (x : int, y : int) (direcion : Direction)  =
  match direcion with
    | North -> (x, y+1)
    | South -> (x, y-1)
    | East -> (x+1, y)
    | West -> (x-1, y)

let duplicates items =
    seq {
        let d = System.Collections.Generic.Dictionary()
        for i in items do
            match d.TryGetValue(i) with
            | false,_    -> d.[i] <- 1                // first observance
            | true,count -> d.[i] <- count+1; yield i // second observance
    }

input
|> (fun (x) -> x.Replace(" ", "").Split([|','|], StringSplitOptions.RemoveEmptyEntries))
|> Array.fold explicit_directions []
|> List.scan move_in_plane (0, 0)
|> duplicates
|> Seq.toArray
|> (fun directions -> 
  let p1, q1 = (0,0)
  let p2, q2 = directions.[0]
  abs(p1 - p2) + abs(q1 - q2) )
