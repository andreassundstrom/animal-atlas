import './taxonomyItemTreeNode.css'

import { Button, IconButton } from "@mui/material"
import { GetTaxonomyItemDto } from "../../api/data-contracts"
import { useTaxonomyContext } from "../../hooks/useTaxonomyContext"
import { Add, KeyboardArrowDown, KeyboardArrowRight, KeyOff } from "@mui/icons-material"
import { useState } from "react"
import { useApi } from '../../hooks/useApi'
import { Link, useNavigate } from 'react-router-dom'
type Props = {
    taxonomyItem: GetTaxonomyItemDto,
    level: number
}

export function TaxonomyItemTreeNode({taxonomyItem, level}:Props){
    const navigate = useNavigate()
    const {setAction} = useTaxonomyContext()
    const [children, setChildren] = useState<GetTaxonomyItemDto[] | null>(null)
    const [expand, setExpand] = useState<boolean>(false)
    const api = useApi()
    const onExpand = (newExpandState : boolean) => {
        setExpand(newExpandState)
        if(newExpandState){
            api?.api
            .v1TaxonomyItemsList({parentId: taxonomyItem.taxonomyItemId})
            .then(res => {
                setChildren(res.data)
            })    
        }
        else{
            setChildren(null)
        }
    }

    return <>
    <ul className={`tree-root tree-root-${level}`}>
        <li>
            <IconButton disabled={taxonomyItem.hasChildren === false} onClick={() => onExpand(!expand)}>
                { taxonomyItem.hasChildren === false ? <KeyOff sx={{color:'rgba(0,0,0,0)'}} /> : expand ? <KeyboardArrowDown /> : <KeyboardArrowRight/> }
            </IconButton>
            <Button component={Link} to={`/taxonomy/${taxonomyItem.taxonomyItemId}`}>
                {taxonomyItem.taxonomyItemName}
            </Button>
            <IconButton onClick={() => setAction({action: 'addChild', taxonomyItemId: taxonomyItem.taxonomyItemId ?? 0})}><Add /></IconButton>
        </li>
        {children && children.map((item) => <TaxonomyItemTreeNode level={level+1}  key={item.taxonomyItemId} taxonomyItem={item} />)}
    </ul>
    </>
}