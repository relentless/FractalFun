// load the script containing the helper functions, and open the module
#load "FractalFunctions.fsx"
open Fractal

showForm() // Draw after the form is displayed - cool but slow

// Function which draws a branch then calls itself recursivelt, to create the pattern
let rec branch (x:float) (y:float) (length:float) (width:float) (angle:float<radians/pi>) (iteration:int) =

    // limit the recursion so it doesn't continue forever
    if iteration < 6 then
        
        // draw the line, and record where it ends
        let nextX, nextY = line x y angle length width (0,0,0)

        // create two more branches, at different angles
        branch nextX nextY (length*0.8) width (angle+0.1<radians/pi>) (iteration+1)
        branch nextX nextY (length*0.8) width (angle-0.1<radians/pi>) (iteration+1)

// Call the branch function with the initial parameters
branch (formWidth/2.0) 150.0 100.0 10.0 0.5<radians/pi> 0

//showForm() // Display the form once it's done - much faster