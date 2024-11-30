import { Alert, Box, Button, FormControl, TextField, Typography } from "@mui/material"
import { useUser } from "../contexts/UserContext"
import { useForm } from "react-hook-form"
import { CreateUserDto } from "../api/data-contracts"
import { useApi } from "../hooks/useApi"
import { useEffect } from "react"

export const Userprofile = () => {
    const user = useUser()
    const api = useApi()
    const {handleSubmit,register,reset,formState: {isDirty}} = useForm<CreateUserDto>({
        defaultValues:{
            email: user?.email ?? '',
            firstName: user?.firstName ?? '',
            lastName: user?.lastName ?? ''
        }
    })

    useEffect(() => {
        reset({
            email: user?.email ?? '',
            firstName: user?.firstName ?? '',
            lastName: user?.lastName ?? ''
        })
    },[user])

    const onSubmit = (user : CreateUserDto) => {
        api?.api.v1UsersUpdate(user).then(() => {

        })
    }
    return <>
    <Typography variant="h3">User profile</Typography>
    {user === undefined &&
        <Alert severity="warning">You need to complete your user profile</Alert>
    }
    {user?.name}
    <form onSubmit={handleSubmit(onSubmit)}>
        <Box sx={{'& .MuiFormControl-root': {mt:2}}}>
            <TextField fullWidth label="First name" {...register('firstName')}/>
            <TextField fullWidth label="Last name" {...register('lastName')}/>
            <TextField fullWidth label="Email" {...register('email')}/>
            <FormControl>
                <Button type="submit" disabled={!isDirty}>Save</Button>
            </FormControl>
        </Box>
    </form>
    </>    
}