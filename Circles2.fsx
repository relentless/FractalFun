// load the script containing the helper functions, and open the module
#load "FractalFunctions.fsx"
open Fractal

let next colour =
    let red, green, blue = colour
    (red, green + 30, blue)

let rand seed =
    let rnd = System.Random(seed)
    rnd.Next(0, 255)

let randCol seed =
    let r = rand seed
    let g = rand r
    let b = rand g
    (r,g,b)

// Function which draws a line then calls itself recursively, to create the pattern
let rec sphere (x:float) (y:float) (radius:float) seed (iteration:int) =

    if radius > 2.0 then
        circle x y (int radius) <| randCol seed

        let nextDist = radius/2.0

        sphere (x+radius) (y) nextDist (seed*2) (iteration+1)
        sphere (x-radius) (y) nextDist (seed/2) (iteration+1)
        sphere (x) (y+radius) nextDist (seed/3) (iteration+1)
        sphere (x) (y-radius) nextDist (seed*3) (iteration+1)

sphere 
    (float formWidth/2.0) // x position - start in the middle
    (float formHeight/2.0) // y position
    200.0 // length of branch
    System.DateTime.Now.Millisecond
    0 // iteration. Could use this to decide how many times to loop.  Or use something else, and get rid of it.

form.Show()