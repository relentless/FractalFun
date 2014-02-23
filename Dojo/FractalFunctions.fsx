module Fractal

// This is based on Mathias Brandewinder's dojo at https://github.com/c4fsharp/Dojo-Fractal-Forest

open System
open System.Drawing
open System.Windows.Forms
open System.Windows
open System.Threading

let red (r, _, _) = r
let green (_, g, _) = g
let blue (_, _, b) = b

let private brush colour = new SolidBrush(Color.FromArgb(colour |> red, colour |> green, colour |> blue))
    
let colourStep startColour endColour numSteps = 
    ((red endColour - red startColour)/numSteps, 
     (green endColour - green startColour)/numSteps, 
     (blue endColour - blue startColour)/numSteps)

// Create a form to display the graphics
let formWidth, formHeight = 1000, 800         
let form = new Form(Width = formWidth, Height = formHeight)
let box = new PictureBox(BackColor = Color.White, Dock = DockStyle.Fill)
let image = new Bitmap(formWidth, formHeight)
let graphics = Graphics.FromImage(image)

let imageCentre = float formWidth/2.0

box.Image <- image
form.Controls.Add(box) 

/// Tells you where a line starting at x,y with the specified angle in radians will end
let endpoint x y angle length =
    x + length * cos angle,
    y + length * sin angle

let private flip y = (float)formHeight - y

let private drawLine (target : Graphics) (brush : Brush) 
             (x : float) (y : float) 
             (angle : float) (length : float) (width : float) =
    let x_end, y_end = endpoint x y angle length
    let origin = new PointF((single)x, (single)(y |> flip))
    let destination = new PointF((single)x_end, (single)(y_end |> flip))
    let pen = new Pen(brush, (single)width)
    target.DrawLine(pen, origin, destination)
    form.Refresh()

let private drawCircle (target : Graphics) (brush : Brush) 
             (x : float) (y : float) 
             (radius : int) =
    target.FillEllipse(brush, (int x-radius), int (flip y)-radius, radius*2, radius*2)

let private drawRectangle (target : Graphics) (brush : Brush) 
             (x : float) (y : float) 
             (width : int) (height : int) =
    target.FillRectangle(brush, int x, int y, width, int height)

/// Draws a line starting at x,y with the specified angle in radians
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

[<Measure>]
type radians

[<Measure>]
type degrees

let toDegrees (rad:float<radians>) =
    pi * rad

let private showForm() =
    let thread = new System.Threading.Thread (
                        new System.Threading.ThreadStart( fun () ->
                                                                //form.Show() |> ignore  
                                                                Application.Run(form)
                                                                form.Focus() |> ignore
                                                                form.BringToFront()
                        )
                    )
    thread.SetApartmentState(System.Threading.ApartmentState.STA)
    thread.IsBackground <- true
    thread.Start()

showForm()

//form.ShowDialog()