------------Breadboard Simulator----------------




------------------Controls----------------------

		   -User Interface-
The user interface can be interacted with by using 
the left mouse click on any of the buttons.
		     -Navigation-
The users position and view of the breadboard can 
be adjusted by holding the left shift key while using 
3 seperate buttons on the mouse:

Left Click: Clicking and dragging will rotate the 
user with the direction you drag

Right Click: Clicking and dragging will zoom  
in and out

Middle Mouse: Clicking and dragging will move the user 
across the breadboard

Scroll: Scrolling will also zoom in and out

-------------------Chips------------------------
 		  _*Hex Inverter*_
  	              ____
	    Input  1[| \/ |]VCC
	    Output 1[|    |]Input  6
	    Input  2[|    |]Output 6 
	    Output 2[|    |]Input  5
	    Input  3[|    |]Output 5 
	    Output 3[| () |]Input  4
	    Ground  [|____|]Output 4

		_*Quad 2-input NAND*_
 			  ____
	   Input  1A[| \/ |]VCC
	   Input  1B[|    |]Input  4B
	   Output 1Y[|    |]Input  4A 
	   Input  2A[|    |]Output 4Y
	   Input  2B[|    |]Input  3B 
	   Output 2Y[| () |]Input  3A
	   Ground   [|____|]Output 4

		_*Quad 2-input AND*_
 			  ____
	   Input  1A[| \/ |]VCC
	   Input  1B[|    |]Input  4B
	   Output 1Y[|    |]Input  4A 
	   Input  2A[|    |]Output 4Y
	   Input  2B[|    |]Input  3B 
	   Output 2Y[| () |]Input  3A
	   Ground   [|____|]Output 4
			  
		_*Quad 2-Input OR*_
			   ____
	   Input  A1[| \/ |]VCC
	   Input  B1[|    |]Input  B4
     	   Output Y1[|    |]Input  A4
	   Input  A2[|    |]Output Y4
	   Input  B2[|    |]Input  B3
	   Output Y2[| () |]Input  A3
	   Ground   [|____|]Output Y3

		_*Quad 2-Input XOR*_
			  ____
	   Output 1Y[| \/ |]VCC
	   Input  1A[|    |]Output 4Y
	   Input  1B[|    |]Input  4B
         Output 2Y[|    |]Input  4A
	   Input  2A[|    |]Output 3Y
	   Input  2B[| () |]Input  3B
	   Ground   [|____|]Input  3A
  		
		_*Quad 2-Input NOR*_
			  ____
	   Output 1Y[| \/ |]VCC
	   Input  1A[|    |]Output 4Y
	   Input  1B[|    |]Input  4B
         Output 2Y[|    |]Input  4A
	   Input  2A[|    |]Output 3Y
	   Input  2B[| () |]Input  3B
	   Ground   [|____|]Input  3A
  		
		_*Quad 2-Input XNOR*_
			  ____
	   Input  1A[| \/ |]VCC
	   Input  1B[|    |]Input  4B
	   Output 1Y[|    |]Input  4A
	   Output 2Y[|    |]Output 4Y
	   Input  2A[|    |]Output 3Y
	   Input  2B[| () |]Input  3B
	   Ground   [|____|]Input  3A
  		     
		_*Triple 3-Input AND*_
                    ____
	   Input  1A[| \/ |]VCC
	   Input  1B[|    |]Input  1C
	   Input  2A[|    |]Output 1Y
	   Input  2B[|    |]Input  3C
	   Input  2C[|    |]Input  3B
	   Output 2Y[| () |]Input  3A
	   Ground   [|____|]Output 3Y
		
		_*Triple 3-Input NAND*_
                    ____
	   Input  1B[| \/ |]VCC
	   Input  1C[|    |]Input  1A
	   Input  2A[|    |]Output 1Y
	   Input  2B[|    |]Input  3C
	   Input  2C[|    |]Input  3B
	   Output 2Y[| () |]Input  3A
	   Ground   [|____|]Output 3Y
		


------------Breadboard Interface----------------

			-Add Wire-
	*Clicking the -Add Wire- button will allow you 
to click two points on the breadboard, and spawns 
a wire, to work correctly and accurately click the 
slot from a top down view, and place the pegs in 
order of source and destination. 
	*After pressing -ADD WIRE-, three small buttons 
should appear stated as -Red-, -Blue-, and -Green-. Clicking 
any of these will change the color of the next placed 
wire. The user will continue to place wires until the 
-Escape- button is pressed.
			-Chip Spawner-
	*By Clicking any of the chip buttons, that 
specific chip will spawn in the middle of the breadboard, 
from there it can be clicked and draged into an appropriate 
position.
			-Remove-
	*By clicking the Remove button any component placed 
can be removed by clicking on it, untill the corresponding 
-Escape- button is pressed

			-Show Diagram-
	*By clicking the -Show Diagram- button, 
the logic diagram for the current breadboard configuration 
is displayed in the left side of the screen. This can be 
hidden by pressing the -Hide Diagram- button

			-Show Criteria-
	*By clicking the -Show Criteria- button, the 
requirements for the specific module is dispayed 
in the top center of the screen for the current 
module This can be hidden by pressing the 
-Hide Criteria- button.

			-Main Menu-
	*By clicking the -Main Menu- button you will be 
returned to the main menu of the application.

			-Clear Board-
	*By clicking the -Clear Board- button the current 
configuration of the breadboard will be wiped.

-----------------Logic Diagram----------------


			-Select Node- 
	*Use Left Mouse Button to slide select table and down. You 
can select a node by clicking on the Left Mouse Button as 
well, where the node will pop up in the middle of the screen.


			-Move Nodes- 
	*Use Left Mouse Button to drag around nodes.

		      -Connect Nodes- 
	*Use Left Mouse Button on one box to drag to another.

			 -Zoom In/Out-
	*Use Right Mouse Button (On trackpad, click on the trackpad
with two fingers: Slide up to zoom out, slide down to zoom in. If 
the screen display is upside down, the slide up/down is reversed).

			 -Move Camera- 
	*Use Middle Mouse Button (On trackpad, click on the trackpad 
with three fingers to move camera around).

			-Duplicate Gates- 
	*Press the D button when you click on a logic gate to duplicate 
that gate.

			 -Delete Gates-
	*Press the delete button when you click on a logic gate to delete 
it (If you are on a macbook, press fn + delete).

		   -Changing Variables- 
	*When you select on a node, there should be an input box on the 
bottom left of the screen, you can edit important information there.

		    -Save Logic Diagram-
	*On the top right, the first box on the top right is the scene name.
You can edit the scene name there to create a new logic diagram 
(MAKE SURE TO CLICK SAVE ONCE YOU CHANGE THE NAME OR ELSE IT WILL 
NOT SAVE ON ITS OWN).You can also load previous logic diagrams using 
the load button right below the save one.
------------------------------------------------

