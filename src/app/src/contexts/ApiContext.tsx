import { createContext, ReactNode, useEffect, useState } from "react";
import { Api } from "../api/Api";
import { useAuth0 } from "@auth0/auth0-react";

type ApiContextData = {
    api: Api,
    token: string | null
} 
export const ApiContextContext = createContext<ApiContextData | undefined>(undefined)

export const ApiContext = ({children}:{children:ReactNode}) => {
    const { getAccessTokenSilently, user } = useAuth0()
    const [api, setApi] = useState<ApiContextData>({
        api: new Api(),
        token: null
    })
    useEffect(() => {
        getAccessTokenSilently()
        .then((res) => {
            setApi({
                api: new Api({
                    headers: {
                        Authorization: `Bearer ${res}`
                    }
                }),
                token: res
            })
        })
        .catch((exception) => {
            console.log(exception)
        })
    },[getAccessTokenSilently, user?.sub])
    
    return <ApiContextContext.Provider value={api}>
        {children}
    </ApiContextContext.Provider>
}