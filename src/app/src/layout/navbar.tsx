import { AppBar, Button, Toolbar } from "@mui/material"
import { Link } from "react-router"

export const Navbar = () => {
    return <AppBar>
        <Toolbar>
        <Button 
            component={Link}
            to=""
            color="inherit">Home</Button>
            <Button
                color="inherit"
                component={Link} 
                to={'taxonomy'}>Taxonomi</Button>
        </Toolbar>
            
    </AppBar>
}