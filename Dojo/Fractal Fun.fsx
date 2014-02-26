// load the script containing the helper functions, and open the module
#load "FractalFunctions.fsx"
open Fractal

showForm() // Showing the form before we start drawing looks cool, but is slow

// Function which draws a line then calls itself recursively, to create the pattern
let rec branch (x:float) (y:float) (length:float) (width:float) (angle:float<radians/pi>) (iteration:int) =

    // draw the line, and record where it ends
    let nextX, nextY = line x y angle length width (0,0,0) // (0,0,0) is the colour, like (r,g,b)

    // YOUR TURN
    // We need more lines! Maybe we could call branch again, with some different angles & stuff?
    // Hell, we could even call it a couple of times, with different angles/lengths/widths/colours...
    // It's all about the Recursion, baby!

    0 // You can't finish a function with a 'let', so for now we'll just return 0


// Call the branch function with the initial parameters
branch 
    (formWidth/2.0) // x position - start in the middle
    150.0 // y position
    100.0 // length of branch
    10.0 // width of branch
    0.5<radians/pi> // angle, in radians/pi.  Full circle = 2*pi radians, so angle is between 0-2.
    0 // iteration. Could use this to decide how many times to loop.  Or use something else, and get rid of it.

//showForm() // Showing the form here is much faster