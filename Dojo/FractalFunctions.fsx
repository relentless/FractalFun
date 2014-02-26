module Fractal

// This is based on Mathias Brandewinder's dojo at https://github.com/c4fsharp/Dojo-Fractal-Forest

open System
open System.Drawing
open System.Windows.Forms
open System.Windows
open System.Threading

// Create a form to display the graphics
let formWidth, formHeight = 1000.0, 800.0         
let private form = new Form(Width = int formWidth, Height = int formHeight)
let private box = new PictureBox(BackColor = Color.White, Dock = DockStyle.Fill)
let private image = new Bitmap(int formWidth, int formHeight)
let private graphics = Graphics.FromImage(image)

box.Image <- image
form.Controls.Add(box) 

let private red (r, _, _) = r
let private green (_, g, _) = g
let private blue (_, _, b) = b

[<Measure>]
type radians

[<Measure>]
type pi

let private PI = 3.14159265359<pi>

let private brush colour = new SolidBrush(Color.FromArgb(colour |> red, colour |> green, colour |> blue))

/// Tells you where a line starting at x,y with the specified angle in radians will end
let private endpoint x y (angle:float<radians/pi>) length =
    let angleRadians = float (PI * angle)
    x + length * cos angleRadians,
    y + length * sin angleRadians

let private flip y = (float)formHeight - y

let private drawLine (target : Graphics) (brush : Brush) 
             (x : float) (y : float) 
             (angle : float<radians/pi>) (length : float) (width : float) =
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
    target.FillRectangle(brush, int x, int (flip y) - height, width, height)

/// Draws a line starting at x,y with the specified angle in radians.
/// Returns the coordinates of the end of the line, as a tuple
let line x y (angle:float<radians/pi>) length width colour = 
    drawLine graphics (colour |> brush) x  y angle length width
    endpoint x y angle length

/// Draws a recangle with bottom left corner at x,y
let rectangle x y width height colour = 
    drawRectangle graphics (colour |> brush) x y width height

/// Draws a circle centred on x,y
let circle x y radius colour = 
    drawCircle graphics (colour |> brush) x y radius

/// Display the form
/// Can be called before of after the drawing has been done
let showForm() =
    let thread = new System.Threading.Thread (
                        new System.Threading.ThreadStart( fun () ->
                                                                Application.Run(form)
                                                                form.Focus() |> ignore
                                                                form.BringToFront()
                        )
                    )
    thread.SetApartmentState(System.Threading.ApartmentState.STA)
    thread.IsBackground <- true
    thread.Start()