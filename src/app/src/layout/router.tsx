import { createBrowserRouter, RouterProvider } from "react-router"
import { Layout } from "./layout"
import { Home } from "../pages/home"
import { Taxonomy } from "../pages/taxonomy"
import { Userprofile } from "../pages/userprofile"

export const Router = () => {
    const router = createBrowserRouter([{
        path: '',
        element: <Layout />,
        children:[
            {
                path:'',
                element: <Home />
            },
            {
                path:'taxonomy/:taxonomyItemId?',
                element: <Taxonomy />
            },
            {
                path:'userprofile',
                element: <Userprofile />
            }
        ]
    }])

    return <RouterProvider router={router} />
}