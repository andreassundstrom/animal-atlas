import { Container } from "@mui/material"
import { Outlet } from "react-router"
import { Navbar } from "./navbar"

export const Layout = () => {
    return <>
    <Navbar />
    <Container>
        <Outlet />
    </Container></>
}