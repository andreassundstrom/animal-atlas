import { Container, CssBaseline } from "@mui/material"
import { Outlet } from "react-router"
import { Navbar } from "./navbar"
import { Auth0Provider } from "@auth0/auth0-react"
import { ApiContext } from "../contexts/ApiContext"
import { UserContext } from "../contexts/UserContext"

export const Layout = () => {
    return <>
    
        <Auth0Provider
      domain="dev-animal-atlas.eu.auth0.com"
      clientId="yfyy8pUfwdYfdRzxFB9prc6eFkj7yWbM"
      authorizationParams={{
          redirect_uri: window.location.origin,
          audience: 'https://animal-atlas.com'
        }}
      
      >
      <CssBaseline />
      <ApiContext>
      <UserContext>
        <Navbar />
        <Container sx={{mt:10}}>
            <Outlet />    
        </Container>
      </UserContext>
      </ApiContext>
    </Auth0Provider>
    </>
}