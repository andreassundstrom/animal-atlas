import { useAuth0 } from "@auth0/auth0-react";
import { createContext, ReactNode, useEffect, useState } from "react";
import { useApi } from "../hooks/useApi";
import { GetUserDto } from "../api/data-contracts";
import { useNavigate } from "react-router";
import { AxiosError } from "axios";

export const UserContextContext = createContext<GetUserDto|undefined>(undefined)

export const UserContext = ({children}:{children:ReactNode|ReactNode[]}) => {
    const [user, setUser] = useState<GetUserDto>()
    const api = useApi()
    const auth = useAuth0()
    const navigate = useNavigate()
    useEffect(() => {
        if(auth.isAuthenticated){
            api.v1UsersList()
            .then(res => {
                const user = res.data;
                setUser(user)
            })
            .catch((err:AxiosError) => {
                if(err.status === 404){
                    navigate('/userprofile')
                }
            })
        }
    },[auth.isAuthenticated, auth.user])

    return <UserContextContext.Provider value={user}>
        {children}
    </UserContextContext.Provider> 
}