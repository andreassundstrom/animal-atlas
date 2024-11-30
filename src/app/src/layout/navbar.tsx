import { useAuth0 } from "@auth0/auth0-react"
import { Logout } from "@mui/icons-material"
import { AppBar, Box, Button, IconButton, Toolbar, Tooltip, Typography } from "@mui/material"
import { Link } from "react-router"
import { useUser } from "../contexts/UserContext"

export const Navbar = () => {
    const auth = useAuth0()
    const user = useUser()
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
            <Box sx={{flexGrow:1}}></Box>
            {
                auth.user &&
                <>
                <Button color="inherit" component={Link} to={'userprofile'}>
                    {user?.name ?? auth.user.name}</Button>
                <Tooltip title="Signout">
                    <IconButton onClick={() => auth.logout()} color="inherit">
                        <Logout/>
                    </IconButton>
                </Tooltip>
                </>
            }
            {
                auth.isAuthenticated === false &&
                <Button 
                    color="inherit"
                    onClick={() => auth.loginWithRedirect()}
                    >
                    Login
                </Button>
            }
        </Toolbar>
            
    </AppBar>
}