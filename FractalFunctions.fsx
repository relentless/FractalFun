module Fractal

// This is based on Mathias Brandewinder's dojo at https://github.com/c4fsharp/Dojo-Fractal-Forest

open System
open System.Drawing
open System.Windows.Forms

let red (r, _, _) = r
let green (_, g, _) = g
let blue (_, _, b) = b

let startColour = (60,30,0) // brown
let endColour = (0,170,0)

let brush colour = new SolidBrush(Color.FromArgb(colour |> red, colour |> green, colour |> blue))
    
let colourStep startColour endColour numSteps = 
    ((red endColour - red startColour)/numSteps, 
     (green endColour - green startColour)/numSteps, 
     (blue endColour - blue startColour)/numSteps)

// Create a form to display the graphics
let formWidth, formHeight = 800, 650         
let form = new Form(Width = formWidth, Height = formHeight)
let box = new PictureBox(BackColor = Color.White, Dock = DockStyle.Fill)
let image = new Bitmap(formWidth, formHeight)
let graphics = Graphics.FromImage(image)

let imageCentre = float formWidth/2.0

box.Image <- image
form.Controls.Add(box) 

let endpoint x y angle length =
    x + length * cos angle,
    y + length * sin angle

let flip y = (float)formHeight - y

let drawLine (target : Graphics) (brush : Brush) 
             (x : float) (y : float) 
             (angle : float) (length : float) (width : float) =
    let x_end, y_end = endpoint x y angle length
    let origin = new PointF((single)x, (single)(y |> flip))
    let destination = new PointF((single)x_end, (single)(y_end |> flip))
    let pen = new Pen(brush, (single)width)
    target.DrawLine(pen, origin, destination)

let drawCircle (target : Graphics) (brush : Brush) 
             (x : float) (y : float) 
             (radius : int) =
    target.FillEllipse(brush, (int x-radius), int (flip y)-radius, radius*2, radius*2)

let drawRectangle (target : Graphics) (brush : Brush) 
             (x : float) (y : float) 
             (width : int) (height : int) =
    target.FillRectangle(brush, int x, int y, width, int height)

let line x y angle length width colour = 
    drawLine graphics (colour |> brush) x  y angle length width

let rect x y width height colour = 
    drawRectangle graphics (colour |> brush) x y width height

let background startHeight endHeight colour =
    rect 0.0 startHeight formWidth endHeight colour

let pi = Math.PI

let next step colour =
    (red colour + red step, 
     green colour + green step, 
     blue colour + blue step)

