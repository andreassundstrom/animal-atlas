/* eslint-disable */
/* tslint:disable */
/*
 * ---------------------------------------------------------------
 * ## THIS FILE WAS GENERATED VIA SWAGGER-TYPESCRIPT-API        ##
 * ##                                                           ##
 * ## AUTHOR: acacode                                           ##
 * ## SOURCE: https://github.com/acacode/swagger-typescript-api ##
 * ---------------------------------------------------------------
 */

export interface CreateTaxonomyGroupDto {
  /** @minLength 1 */
  taxonomyGroupName: string;
}

export interface CreateTaxonomyItemDto {
  /** @minLength 1 */
  taxonomyItemName: string;
  /** @format int32 */
  parentId?: number | null;
  /** @format int32 */
  groupId: number;
}

export interface GetTaxonomyGroupDto {
  /** @format int32 */
  taxonomyGroupId?: number;
  taxonomyGroupName?: string | null;
}

export interface GetTaxonomyItemDto {
  /** @format int32 */
  taxonomyItemId?: number;
  taxonomyItemName?: string | null;
  /** @format int32 */
  parentId?: number | null;
  hasChildren?: boolean;
}

export interface GetUserDto {
  firstName?: string | null;
  lastName?: string | null;
  name?: string | null;
  email?: string | null;
  userProfileCompleted?: boolean;
  isAdmin?: boolean | null;
  isSysadmin?: boolean | null;
}
