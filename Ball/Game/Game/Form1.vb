Public Class Form1
    Dim frame As Bitmap
    Dim g, gFinal As Graphics
    'ball position
    Dim ballX, ballY As Integer
    'ball velocity
    Dim ballDx, ballDy As Integer

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        'DRAW STUFF HERE
        '---------------

        'Draw your background first!
        g.Clear(Color.Black)

        'Update ball location
        ballX = ballX + ballDx
        ballY = ballY + ballDy

        'Draw ball
        Dim ball As New Rectangle(ballX, ballY, 20, 20)
        g.FillEllipse(Brushes.White, ball)

        'Walls
        Dim bottom As New Rectangle(0, getHeight() - 10, getWidth, 20)
        g.DrawRectangle(Pens.Red, bottom)
        Dim top As New Rectangle(0, -15, getWidth, 20)
        g.DrawRectangle(Pens.Red, top)


        'Ball bounce
        If ball.IntersectsWith(bottom) Or ball.IntersectsWith(top) Then
            ballDy = ballDy * -1
        End If





        'Do not alter this line
        gFinal.DrawImage(frame, 0, 0)
        'Check for collisions below

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Do not alter this code
        frame = New Bitmap(getWidth(), getHeight())
        gFinal = Me.CreateGraphics
        g = Graphics.FromImage(frame)

        gFinal.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        gFinal.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        gFinal.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
        gFinal.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality

        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality

        GameTimer.Start()

        'Initial position and speed
        ballDx = 2
        ballDy = 5
        ballX = 0
        ballY = 100
    End Sub

    Function getWidth() As Integer
        'Returns the usable width of the form
        Return Me.ClientSize.Width
    End Function
    Function getHeight() As Integer
        'Returns the usable height of the form
        Return Me.ClientSize.Height
    End Function
End Class
