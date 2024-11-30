import { Dialog, DialogContent, DialogTitle, FormControl, TextField, InputLabel, Select, MenuItem, DialogActions, Button, Grid2, Typography } from "@mui/material"
import { useState, useEffect } from "react"
import { useForm, Controller } from "react-hook-form"
import { CreateTaxonomyItemDto, GetTaxonomyItemDto, GetTaxonomyGroupDto } from "../../api/data-contracts"
import { useTaxonomyContext } from "../../hooks/useTaxonomyContext"
import { TaxonomyItemTreeNode } from "./taxonomyItemTreeNode"
import { useApi } from "../../hooks/useApi"
import { useParams } from "react-router"
import { TaxonomyItemView } from "./taxonomyItemView"

export const TaxonomyListBase = () => {
    const api = useApi()
    const { taxonomyId } = useParams()
    const {register, handleSubmit, control} = useForm<CreateTaxonomyItemDto>({
        defaultValues: {parentId: null, taxonomyItemName: '', groupId: 0}
    })
    const [taxonomyList, setTaxonomyList ] = useState<GetTaxonomyItemDto[]>()
    const [taxonomyGroup, setTaxonomyGroup] = useState<GetTaxonomyGroupDto[]>()
    const {action, setAction} = useTaxonomyContext()
    const closeDialog = () => setAction(null)
    useEffect(() => {
        api?.api
        .v1TaxonomyItemsList()
        .then(res => setTaxonomyList(res.data))

        api?.api
        .v1TaxonomyGroupsList()
        .then(res => setTaxonomyGroup(res.data))
    },[])

    const onSubmit = (taxonomyItem : CreateTaxonomyItemDto) => {
        taxonomyItem.parentId = action?.taxonomyItemId
        api?.api
            .v1TaxonomyItemsCreate(taxonomyItem)
            .then(() => {
                // refresh?
                closeDialog()
            })
    }

    return <>
    {action?.action === "addChild" && 
    <Dialog fullWidth open onClose={closeDialog}>
        <form onSubmit={handleSubmit(onSubmit)}>
        <DialogContent sx={{'& > .MuiFormControl-root': {mt:2}}}>
            <DialogTitle>Add child to {action.taxonomyItemId}</DialogTitle>
            <FormControl fullWidth>
                <TextField {...register('taxonomyItemName')} label="Name" fullWidth />
            </FormControl>
            <FormControl fullWidth>
            <InputLabel>Group</InputLabel>
            <Controller
                control={control}
                name="groupId"
                render={({field}) =>
                <Select label="Group" fullWidth value={field.value !== 0 ? field.value : ''} onChange={e => field.onChange(e.target.value)}>
                    {taxonomyGroup?.map(p => <MenuItem key={p.taxonomyGroupId} value={p.taxonomyGroupId}>{p.taxonomyGroupName}</MenuItem>)}
                </Select>
                }
            />
            </FormControl>
            <DialogActions>
                <Button onClick={closeDialog}>Cancel</Button>
                <Button onClick={handleSubmit(onSubmit)}>Save</Button>
            </DialogActions>
        </DialogContent>
        </form>
        </Dialog>}
        <Grid2 container>
            <Grid2 size={4}>
            {taxonomyList && taxonomyList.map((map) =>
        <TaxonomyItemTreeNode level={0} key={map.taxonomyItemId} taxonomyItem={map} />)}
            </Grid2>
            <Grid2 size={8}>
                <TaxonomyItemView />
            </Grid2>
        </Grid2>
        </>
    
}